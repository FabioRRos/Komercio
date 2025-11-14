package service

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type ProductService interface {
	CreateProduct(ctx context.Context, product *entity.Product) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	SelectProductById(ctx context.Context, id int) (*entity.Product, error)
	SelectProductByCodBar(ctx context.Context, productcodbar string) (*entity.Product, error)
	UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error)
	DeactivateProduct(ctx context.Context, id int) error
	UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int) (*entity.Product, error)
	UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error
	SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error)
	UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error
}

type productService struct {
	repo repository.ProductRepository
}

func NewProductService(repo repository.ProductRepository) ProductService {
	return &productService{repo: repo}
}

func (s *productService) CreateProduct(ctx context.Context, product *entity.Product) error {
	if product == nil {
		return errors.New("produto não pode ser nulo")
	}

	if err := entity.ProductValidation(*product); err != nil {
		return errors.New("parâmetros inválidos")
	}

	if product.ProductCodBar == "" {
		product.ProductCodBar = entity.CreateCodbar()
	}

	return s.repo.Create(ctx, product)
}

func (s *productService) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	products, err := s.repo.SelectAllProducts(ctx)
	if err != nil {
		return nil, err
	}

	// Filtra apenas produtos ativos
	var activeProducts []*entity.Product
	for _, p := range products {
		if p.ProductStatus {
			activeProducts = append(activeProducts, p)
		}
	}

	return activeProducts, nil
}

func (s *productService) SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error) {
	products, err := s.repo.SelectProductSettings(ctx)

	if err != nil {
		return nil, err
	}

	return products, nil

}

func (s *productService) SelectProductById(ctx context.Context, id int) (*entity.Product, error) {
	if id <= 0 {
		return nil, errors.New("id inválido")
	}

	product, err := s.repo.SelectProductById(ctx, id)
	if err != nil {
		return nil, err
	}

	return product, nil
}

func (s *productService) SelectProductByCodBar(ctx context.Context, ProductcodBar string) (*entity.Product, error) {
	if ProductcodBar == "" {
		return nil, errors.New("Codigo de barras inválido")
	}

	product, err := s.repo.SelectProductByCodBar(ctx, ProductcodBar)
	if err != nil {
		return nil, err
	}

	return product, nil
}

func (s *productService) UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error) {
	if product == nil || product.Id <= 0 {
		return nil, errors.New("produto inválido para atualização")
	}

	if err := entity.ProductValidation(*product); err != nil {
		return nil, errors.New("parâmetros inválidos")
	}

	updated, err := s.repo.UpdateProduct(ctx, product)
	if err != nil {
		return nil, err
	}

	return updated, nil
}

func (s *productService) UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int) (*entity.Product, error) {
	update, err := s.repo.UpdateProductInputStock(ctx, productcodbar, productStock)
	if err != nil {
		return nil, err
	}

	return update, nil
}

func (s *productService) DeactivateProduct(ctx context.Context, id int) error {
	if id <= 0 {
		return errors.New("id inválido")
	}
	return s.repo.DeactivateProduct(ctx, id)
}

func (s *productService) UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error {

	if productcodbar == "" {
		return errors.New("código de barras inválido")
	}

	if productStock <= 0 {

		return errors.New(fmt.Errorf("Quantidade em estoque inválida %v", productStock).Error())
	}

	return s.repo.UpdateProductOutputStockTX(ctx, tx, productcodbar, productStock)
}

func (s *productService) UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error {

	if len(productList) == 0 {
		return fmt.Errorf("lista de produtos vazia")
	}

	for _, k := range productList {

		if k.Id_productNotification <= 0 {
			return fmt.Errorf("id inválido %d para o produto %s",
				k.Id_productNotification,
				k.Productname,
			)
		}

		if k.Productstock < 0 {
			return fmt.Errorf("estoque mínimo negativo (%d) no produto %s",
				k.Productstock, k.Productname)
		}
	}

	return s.repo.UpdateProductNotification(ctx, productList)
}
