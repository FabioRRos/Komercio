package service

import (
	"context"
	"fmt"
	"strconv"
	"time"

	"github.com/fabioros/Komercio/domain/entity"
)

// Interface do serviço  define o contrato
type FullSaleService interface {
	CreateFullSale(ctx context.Context, fullSale *entity.SaleAggregate) (int, error)
	//GetFullSaleById(ctx context.Context, id int) (*entity.SaleAggregate, error)
}

func NewFullSaleService(
	salesService SalesService,
	saleItemsService SaleItemsService,
	cashmovementService CashmovementService,
	product ProductService,
	transation CustomertransactionService,
	caixaService CaixaService,
	formaPagamento FormaPagamentoService,
	serv PrecoCompraService,
) FullSaleService {
	return &fullSaleService{
		salesService:        salesService,
		saleItemsService:    saleItemsService,
		cashMovementService: cashmovementService,
		product:             product,
		transation:          transation,
		caixaService:        caixaService,
		formaPagamento:      formaPagamento,
		serv:                serv,
	}
}

// Estrutura que implementa a interface
// Agora o FullSaleService utiliza o serviço de repositório de outras rotas.

type fullSaleService struct {
	salesService        SalesService
	saleItemsService    SaleItemsService
	cashMovementService CashmovementService
	product             ProductService
	transation          CustomertransactionService
	caixaService        CaixaService
	formaPagamento      FormaPagamentoService
	serv                PrecoCompraService
}

func (s *fullSaleService) CreateFullSale(ctx context.Context, salesAggregate *entity.SaleAggregate) (int, error) {
	now := time.Now()
	//chamo a validação financeira da venda
	err := entity.Valedatecalcofsale(salesAggregate)
	if err != nil {
		return 0, fmt.Errorf("Erro na validação financeira da tranzação. %w", err)
	}

	// Inicia transação no banco via repository
	tx, err := s.salesService.BeginTransaction(ctx)
	if err != nil {
		return 0, fmt.Errorf("erro ao iniciar transação: %w", err)
	}
	defer tx.Rollback(ctx) // rollback automático se algo der errado

	// Cria a venda principal
	sale := salesAggregate.Sale
	sale.SalesDate = now
	sale.SalesHour = now.Format("15:04:05")

	saleID, err := s.salesService.CreateNewSaleTx(ctx, tx, &sale)
	if err != nil {
		return 0, fmt.Errorf("erro ao criar venda: %w", err)
	}

	// Insere os itens da venda
	for _, item := range salesAggregate.Items {
		saleItem := entity.SalesItens{
			SaleId:      saleID,
			ProductId:   item.ProductId,
			ProductName: item.ProductName,
			Barcode:     item.Barcode,
			UnitPrice:   item.UnitPrice,
			Quantity:    item.Quantity,
			Total:       item.Total,
		}

		if err := s.saleItemsService.CreateSaleItemTx(ctx, tx, &saleItem); err != nil {
			return 0, fmt.Errorf("erro ao inserir item '%s': %w", item.ProductName, err)

		}

	}

	// Registra a movimentação de caixa
	cashMovement := entity.Cashmovements{
		SalesId:                  saleID,
		Cashmovementstype:        salesAggregate.CashMovement.Cashmovementstype,
		Cashmovementsdescription: salesAggregate.CashMovement.Cashmovementsdescription,
		Cashmovementsamount:      salesAggregate.CashMovement.Cashmovementsamount,
		//Abaixo teremos formas unicas como dinheiro, cartão, cheque, conta ou "Misto"
		Cashmovementspaymentmethod: salesAggregate.CashMovement.Cashmovementspaymentmethod,
		Cashmovementsdatetime:      now,
		SellerId:                   salesAggregate.CashMovement.SellerId,
	}

	if err := s.cashMovementService.CreateCashmovementTx(ctx, tx, &cashMovement, salesAggregate.FormaPpagamento); err != nil {
		return 0, fmt.Errorf("erro ao registrar movimentação de caixa: %w", err)
	}

	// baixa o estoque dos produtos vendidos

	for _, item := range salesAggregate.Items {
		codebar := item.Barcode
		quantity := item.Quantity

		if err := s.product.UpdateProductOutputStockTX(ctx, tx, codebar, quantity); err != nil {
			return 0, fmt.Errorf("erro ao baixar estoque dos produtos vendidos: %w", err)
		}
	}

	// aqui eu deixei o IF de lado e vou utilizar o Swithch para tratar as formas de pagamento
	// Basicamente eu vou rodar a lista de forma de pagamento para adiciona-las onde elas devem ser adicionadas.

	for _, forma := range salesAggregate.FormaPpagamento {
		switch forma.Forma_de_pagamento {
		case "Conta":
			{
				newTransation := entity.CustomerTransaction{
					Sale_id:           saleID,
					Customer_id:       sale.CustomerId,
					Origin_type:       "Venda", // Sempre será entrada
					Transaction_value: forma.Valor_pago,
					Transaction_date:  cashMovement.Cashmovementsdatetime,
					Obs:               sale.SaleNotes,
					Seller:            strconv.Itoa(cashMovement.SellerId),
					Type_payment:      forma.Forma_de_pagamento,
				}
				if err := s.transation.CreateTransactionTX(ctx, tx, &newTransation); err != nil {
					return 0, fmt.Errorf("erro ao tentar salvar transição na conta\nErro: %w", err)
				}
			}
		case "Dinheiro":
			{
				// Atualiza o caixa
				caixaChange := entity.Caixa{
					ValueChanged: forma.Valor_pago,
					ChangeType:   "entrada",
					ChangeOrigin: "venda",
					ChangeDate:   now,
					VendedorID:   cashMovement.SellerId,
					Status:       true,
					Observations: fmt.Sprintf("Venda ID %d", saleID),
				}
				if err := s.caixaService.CaixaChangeTX(ctx, tx, &caixaChange); err != nil {
					return 0, fmt.Errorf("erro ao atualizar o caixa: %w", err)
				}
			}
		default:
			{
				// Outras formas de pagamento podem ser tratadas aqui
			}
		}

	}

	//Se tudo deu certo, confirma a transação
	if err := tx.Commit(ctx); err != nil {
		return 0, fmt.Errorf("erro ao confirmar transação: %w", err)
	}

	// aaqui vou baixar a lista dos produtos.
	for _, item := range salesAggregate.Items {
		if err := s.serv.BaixarProdutosListaDePrecos(ctx, item.Barcode, item.Quantity); err != nil {
			return saleID, err

		}
	}

	return saleID, err
}
