package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type SaleItemsService interface {
	CreateSaleItem(ctx context.Context, item *entity.SalesItens) error
	GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error)
	GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error)

	// 🔹 Novo método: inserir item dentro de uma transação
	CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error
}

type saleItemsService struct {
	repo repository.SaleItemsRepository
}

func NewSaleItemsService(repo repository.SaleItemsRepository) SaleItemsService {
	return &saleItemsService{
		repo: repo,
	}
}

// =============================================================
// Criar item fora de transação
func (s *saleItemsService) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {
	if err := validateSaleItem(item); err != nil {
		return err
	}
	return s.repo.CreateSaleItem(ctx, item)
}

// =============================================================
// Criar item dentro de uma transação
func (s *saleItemsService) CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error {
	if err := validateSaleItem(item); err != nil {
		return err
	}
	return s.repo.CreateSaleItemTx(ctx, tx, item)
}

// =============================================================
// Buscar todos os itens
func (s *saleItemsService) GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error) {
	return s.repo.GetAllSaleItems(ctx)
}

// =============================================================
// Buscar itens por ID da venda
func (s *saleItemsService) GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error) {
	if saleId == 0 {
		return nil, errors.New("sale_id inválido")
	}
	return s.repo.GetItemsBySaleId(ctx, saleId)
}

// =============================================================
// Validação compartilhada (evita duplicação de código)
func validateSaleItem(item *entity.SalesItens) error {
	if item == nil {
		return errors.New("item não pode ser nulo")
	}
	if item.SaleId == 0 {
		return errors.New("sale_id é obrigatório")
	}
	if item.ProductId == 0 {
		return errors.New("product_id é obrigatório")
	}
	if item.Quantity <= 0 {
		return errors.New("quantidade deve ser maior que zero")
	}
	if item.UnitPrice <= 0 {
		return errors.New("preço unitário inválido")
	}
	if item.Total == 0 {
		item.Total = item.UnitPrice * float32(item.Quantity)
	}
	return nil
}
