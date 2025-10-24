package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type SaleItemsService interface {
	CreateSaleItem(ctx context.Context, item *entity.SalesItens) error
	GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error)
	GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error)
}

type saleItemsService struct {
	repo repository.SaleItemsRepository
}

func NewSaleItemsService(repo repository.SaleItemsRepository) SaleItemsService {
	return &saleItemsService{
		repo: repo,
	}
}

func (s *saleItemsService) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {
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

	return s.repo.CreateSaleItem(ctx, item)
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
