package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ProductRepository interface {
	Create(ctx context.Context, product *entity.Product) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	SelectProductById(ctx context.Context, id int) (*entity.Product, error)
	UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error)
	DeactivateProduct(ctx context.Context, id int) error
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

func (r *productRepository) SelectProductById(ctx context.Context, id int) (*entity.Product, error) {
	return r.datastore.SelectProductById(id)
}

func (r *productRepository) UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error) {
	return r.datastore.UpdateProduct(product)
}

func (r *productRepository) DeactivateProduct(ctx context.Context, id int) error {
	return r.datastore.DeactivateProduct(id)
}
