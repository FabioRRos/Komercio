package service

import (
	"context"
	"fmt"
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
) FullSaleService {
	return &fullSaleService{
		salesService:        salesService,
		saleItemsService:    saleItemsService,
		cashMovementService: cashmovementService,
		product:             product,
		transation:          transation,
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
}

func (s *fullSaleService) CreateFullSale(ctx context.Context, salesAggregate *entity.SaleAggregate) (int, error) {
	now := time.Now()

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
		SalesId:                    saleID,
		Cashmovementstype:          salesAggregate.CashMovement.Cashmovementstype,
		Cashmovementsdescription:   salesAggregate.CashMovement.Cashmovementsdescription,
		Cashmovementsamount:        salesAggregate.CashMovement.Cashmovementsamount,
		Cashmovementspaymentmethod: salesAggregate.CashMovement.Cashmovementspaymentmethod,
		Cashmovementsdatetime:      now,
		SellerId:                   salesAggregate.CashMovement.SellerId,
	}

	if err := s.cashMovementService.CreateCashmovementTx(ctx, tx, &cashMovement); err != nil {
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

	newTransation := entity.CustomerTransaction{
		Sale_id:           saleID,
		Customer_id:       sale.CustomerId,
		Origin_type:       "Entrada",
		Transaction_value: cashMovement.Cashmovementsamount,
		Transaction_date:  cashMovement.Cashmovementsdatetime,
		Obs:               sale.SaleNotes,
		Seller:            cashMovement.SellerId,
		Type_payment:      cashMovement.Cashmovementspaymentmethod,
	}

	if err := s.transation.CreateTransactionTX(ctx, tx, &newTransation); err != nil {
		return 0, fmt.Errorf("erro ao tentar salvar transição na conta\nErro: %w", err)
	}

	//

	//Se tudo deu certo, confirma a transação
	if err := tx.Commit(ctx); err != nil {
		return 0, fmt.Errorf("erro ao confirmar transação: %w", err)
	}

	return saleID, nil
}
