package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ProductService interface {
	CreateProduct(ctx context.Context, product *entity.Product) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	SelectProductById(ctx context.Context, id int) (*entity.Product, error)
	UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error)
	DeactivateProduct(ctx context.Context, id int) error
	UpdateProductInputStock(ctx context.Context, productId int, productStock int) (*entity.Product, error)
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

func (s *productService) UpdateProductInputStock(ctx context.Context, productId int, productStock int) (*entity.Product, error) {
	update, err := s.repo.UpdateProductInputStock(ctx, productId, productStock)
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
