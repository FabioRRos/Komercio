package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type SaleItemsRepository interface {
	CreateSaleItem(ctx context.Context, item *entity.SalesItens) error
	GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error)
	GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error)
}

type saleItemsRepository struct {
	datastore *datastore.SaleItemsDatastore
}

func NewSaleItemsRepository(ds *datastore.SaleItemsDatastore) SaleItemsRepository {
	return &saleItemsRepository{
		datastore: ds,
	}
}

func (r *saleItemsRepository) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {
	return r.datastore.CreateSaleItem(ctx, item)
}

func (r *saleItemsRepository) GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error) {
	return r.datastore.GetAllSaleItems(ctx)
}

func (r *saleItemsRepository) GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error) {
	return r.datastore.GetItemsBySaleId(ctx, saleId)
}
