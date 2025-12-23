package service

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type SaleItemsService interface {
	CreateSaleItem(ctx context.Context, item *entity.SalesItens) error
	GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error)
	GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error)
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

// Criar item fora de transação (não valida se deu erro em algum lugar da execução)
func (s *saleItemsService) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {

	if item == nil {
		return errors.New(fmt.Sprintf("Item da venda não pode ser nulo.\nItem: %+v", item.ProductId))
	}

	saleItensvalidation, err := entity.ValidateSaleItem(item)
	if err != nil {
		return err
	}
	return s.repo.CreateSaleItem(ctx, saleItensvalidation)
}

// Criar item dentro de uma transação (aqui valida se deu bom ou não. Se der ruim, deve retornar um erro)
func (s *saleItemsService) CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error {

	if item == nil {
		return errors.New(fmt.Sprintf("Item da venda não pode ser nulo.\nItem: %+v", item.ProductId))
	}

	saleItensvalidation, err := entity.ValidateSaleItem(item)
	if err != nil {
		return err
	}

	return s.repo.CreateSaleItemTx(ctx, tx, saleItensvalidation)
}

func (s *saleItemsService) GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error) {
	return s.repo.GetAllSaleItems(ctx)
}

func (s *saleItemsService) GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error) {
	if saleId == 0 {
		return nil, errors.New("sale_id inválido")
	}
	return s.repo.GetItemsBySaleId(ctx, saleId)
}
