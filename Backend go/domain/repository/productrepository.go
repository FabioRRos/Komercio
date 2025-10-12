package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ProductRepository interface {
	Create(ctx context.Context, product *entity.Product) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
}

type productRepository struct {
	datastore *datastore.ProductDatastore
}

func NewProductRepository(ds *datastore.ProductDatastore) ProductRepository {
	return &productRepository{
		datastore: ds,
	}
}

func (r *productRepository) Create(ctx context.Context, product *entity.Product) error {
	return r.datastore.CreateProduct(product)
}

func (r *productRepository) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	return r.datastore.SelectAllProducts()
}
