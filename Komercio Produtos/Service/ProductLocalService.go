package service

import (
	"context"

	entity "github.com/fabioros/komercio/Entity"
	repository "github.com/fabioros/komercio/Repository"
)

type ProductLocalService interface {
	SelectAllProducts(ctx context.Context) error
	UpdateAllProducts(ctx context.Context, produto *entity.PrecoCompra) error
}

type productService struct {
	repo repository.ProductLocalRepository
}

func NewProductService(repo repository.ProductLocalRepository) ProductLocalService {
	return &productService{
		repo: repo,
	}
}

func (s *productService) SelectAllProducts(ctx context.Context) error {
	lista, err := s.repo.SelectAllProducts(ctx)
	if err != nil {
		return err
	}

	for _, k := range lista {
		l, err := entity.ProductToPrecoCompra(k)
		if err != nil {
			return err
		}

		if err := s.UpdateAllProducts(ctx, l); err != nil {
			return err
		}
	}

	return nil
}

func (s *productService) UpdateAllProducts(ctx context.Context, produto *entity.PrecoCompra) error {

	err := s.repo.UpdateAllProducts(ctx, produto)
	return err
}
