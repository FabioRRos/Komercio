package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ProductGroupService interface {
	CreateProductGroup(ctx context.Context, productgroup *entity.ProductGroup) error
	SelectallProductGroup(ctx context.Context) ([]*entity.ProductGroup, error)
}

type productGroupService struct {
	repo repository.ProductGroupRepository
}

func NewProductGroupService(repo repository.ProductGroupRepository) ProductGroupService {
	return &productGroupService{repo: repo}
}

func (s *productGroupService) CreateProductGroup(ctx context.Context, productgroup *entity.ProductGroup) error {
	return s.repo.Create(ctx, productgroup)
}

func (s *productGroupService) SelectallProductGroup(ctx context.Context) ([]*entity.ProductGroup, error) {

	productGroup, err := s.repo.SelectAllProductGroup(ctx)

	if err != nil {
		return nil, err
	}

	return productGroup, nil

}
