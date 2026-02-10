package repository

import (
	"context"

	"github.com/jackc/pgx/v5"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/clients"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ProductRepository interface {
	Create(ctx context.Context, product *entity.Product) error
	CreateProductDescarte(ctx context.Context, productDescarte *entity.ProducrtDescarte) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	SelectProductById(ctx context.Context, id int) (*entity.Product, error)
	UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error)
	DeactivateProduct(ctx context.Context, id int) error
	UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int) (*entity.Product, error)
	UpdateProductOutputStock(ctx context.Context, productcodebar string) error
	UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error
	SelectProductByCodBar(ctx context.Context, productcodbar string) (*entity.Product, error)
	SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error)
	UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error
	GetCodbarBySaleId(ctx context.Context, saleId int) ([]*datastore.ProductCodBarQuantity, error)
}

type productRepository struct {
	datastore *datastore.ProductDatastore
	clients   *clients.ProdutosClient
}

func NewProductRepository(ds *datastore.ProductDatastore,
	cl *clients.ProdutosClient) ProductRepository {
	return &productRepository{
		datastore: ds,
		clients:   cl,
	}
}

func (r *productRepository) Create(ctx context.Context, product *entity.Product) error {
	//return r.datastore.CreateProduct(product)
	return r.clients.Create(ctx, product)
}

func (r *productRepository) CreateProductDescarte(ctx context.Context, productDescarte *entity.ProducrtDescarte) error {
	return r.datastore.CreateProductDescarte(productDescarte)
}

func (r *productRepository) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	//return r.datastore.SelectAllProducts()
	return r.clients.SelectAllProducts(ctx)
}

func (r *productRepository) SelectProductById(ctx context.Context, id int) (*entity.Product, error) {
	//return r.datastore.SelectProductById(id)
	return r.clients.SelectProductById(ctx, id)
}

func (r *productRepository) SelectProductByCodBar(ctx context.Context, productcodbar string) (*entity.Product, error) {
	return r.datastore.SelectProductByCodBar(productcodbar)
}

func (r *productRepository) UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error) {
	return r.datastore.UpdateProduct(product)
}

func (r *productRepository) UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int) (*entity.Product, error) {
	return r.datastore.UpdateProductInputStock(productcodbar, productStock)
}

func (r *productRepository) DeactivateProduct(ctx context.Context, id int) error {
	return r.datastore.DeactivateProduct(id)
}

func (r *productRepository) UpdateProductOutputStock(ctx context.Context, productcodbar string) error {
	return r.datastore.UpdateProductOutputStock(productcodbar)
}

func (r *productRepository) UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error {
	return r.datastore.UpdateProductOutputStockTX(ctx, tx, productcodbar, productStock)
}

func (r *productRepository) SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error) {
	return r.datastore.SelectProductSettings()
}

func (r *productRepository) UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error {
	return r.datastore.UpdateProductNotification(ctx, productList)
}

func (r *productRepository) GetCodbarBySaleId(ctx context.Context, saleId int) ([]*datastore.ProductCodBarQuantity, error) {
	return r.datastore.GetCodbarBySaleId(saleId)
}
