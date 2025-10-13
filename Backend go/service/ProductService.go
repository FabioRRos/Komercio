package service

import (
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ProductService interface {
	CreateProduct(product *entity.Product) error
	SelectAllProducts() ([]*entity.Product, error)
	SelectProductById(id int) (*entity.Product, error)
	UpdateProduct(product *entity.Product) (*entity.Product, error)
	DeactivateProduct(id int) error
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
	// Passou todas as validações -> salva no banco
	return s.repo.Create(nil, product)
}

func (s *productService) SelectAllProducts() ([]*entity.Product, error) {

	products, err := s.repo.SelectAllProducts(nil)
	if err != nil {
		return nil, err
	}

	activeProducts := products[:0]
	for _, p := range products {
		if p.ProductStatus {
			activeProducts = append(activeProducts, p)
		}
	}

	return activeProducts, nil
}

func (s *productService) SelectProductById(id int) (*entity.Product, error) {
	produc, err := s.repo.SelectProductById(nil, id)

	if err != nil {
		return nil, err

	}

	return produc, nil
}

func (s *productService) UpdateProduct(product *entity.Product) (*entity.Product, error) {

	err := entity.ProductValidation(*product)
	if err != nil {
		return nil, err
	}
	// Passou todas as validações -> salva no banco

	produc, err := s.repo.UpdateProduct(nil, product)

	if err != nil {
		return nil, err
	}
	return produc, nil
}

func (s *productService) DeactivateProduct(id int) error {
	return s.repo.DeactivateProduct(nil, id)

}
