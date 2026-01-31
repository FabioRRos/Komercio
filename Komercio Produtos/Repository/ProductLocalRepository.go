package repository

import (
	"context"

	datastore "github.com/fabioros/komercio/DataStore"
	entity "github.com/fabioros/komercio/Entity"
)

type ProductLocalRepository interface {
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	UpdateAllProducts(ctx context.Context, produto *entity.PrecoCompra) error
}

type productRepository struct {
	datastore *datastore.ProductLocalDataStore
}

func NewProductRepository(ds *datastore.ProductLocalDataStore) ProductLocalRepository {
	return &productRepository{
		datastore: ds,
	}
}

func (r *productRepository) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	return r.datastore.SelectAllProducts(ctx)
}

func (r *productRepository) UpdateAllProducts(ctx context.Context, produto *entity.PrecoCompra) error {
	return r.datastore.UpdateAllProducts(ctx, produto)
}
