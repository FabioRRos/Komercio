package service

import (
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ProductService interface {
	CreateProduct(product *entity.Product) error
	SelectAllProducts() ([]*entity.Product, error)
}

type productService struct {
	repo repository.ProductRepository
}

func NewProductService(repo repository.ProductRepository) ProductService {
	return &productService{
		repo: repo,
	}
}

func (s *productService) CreateProduct(product *entity.Product) error {

	err := entity.ProductValidation(*product)

	if err != nil {
		return err
	}
	// Passou todas as validações → salva no banco
	return s.repo.Create(nil, product) // <- ponteiro
}

func (s *productService) SelectAllProducts() ([]*entity.Product, error) {
	return s.repo.SelectAllProducts(nil) // passa o contexto se quiser
}
