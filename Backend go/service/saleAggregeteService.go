package service

import (
	"context"
	"fmt"
	"time"

	"github.com/fabioros/Komercio/domain/entity"
)

// Interface do serviço — define o contrato
type FullSaleService interface {
	CreateFullSale(ctx context.Context, fullSale *entity.SaleAggregate) (int, error)
	//GetFullSaleById(ctx context.Context, id int) (*entity.SaleAggregate, error)
}

func NewFullSaleService(
	salesService SalesService,
	saleItemsService SaleItemsService,
	cashmovementService CashmovementService,
) FullSaleService {
	return &fullSaleService{
		salesService:        salesService,
		saleItemsService:    saleItemsService,
		cashMovementService: cashmovementService,
	}
}

// Estrutura concreta que implementa a interface
// Agora o FullSaleService depende dos outros serviços, e não de um repositório
type fullSaleService struct {
	salesService        SalesService
	saleItemsService    SaleItemsService
	cashMovementService CashmovementService
}

func (s *fullSaleService) CreateFullSale(ctx context.Context, salesAggregate *entity.SaleAggregate) (int, error) {
	now := time.Now()

	// 1️Inicia transação no banco via repository
	tx, err := s.salesService.BeginTransaction(ctx)
	if err != nil {
		return 0, fmt.Errorf("erro ao iniciar transação: %w", err)
	}
	defer tx.Rollback(ctx) // rollback automático se algo der errado

	// 2️Cria a venda principal
	sale := salesAggregate.Sale
	sale.SalesDate = now
	sale.SalesHour = now.Format("15:04:05")

	saleID, err := s.salesService.CreateNewSaleTx(ctx, tx, &sale)
	if err != nil {
		return 0, fmt.Errorf("erro ao criar venda: %w", err)
	}

	// 3️Insere os itens da venda
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

	// 4️⃣ Registra a movimentação de caixa
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

	// 5️⃣ Se tudo deu certo, confirma a transação
	if err := tx.Commit(ctx); err != nil {
		return 0, fmt.Errorf("erro ao confirmar transação: %w", err)
	}

	return saleID, nil
}
