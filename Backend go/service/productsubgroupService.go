package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ProductSubgroupService interface {
	CreateProductSubgroup(ctx context.Context, productsubgroup *entity.ProductSubGroup) error
	SelectallProductSubgroup(ctx context.Context) ([]*entity.ProductSubGroup, error)
}

type productSubgroupService struct {
	repo repository.ProductSubgroupRepository
}

func NewProductSubgroupService(repo repository.ProductSubgroupRepository) ProductSubgroupService {
	return &productSubgroupService{repo: repo}
}

func (s *productSubgroupService) CreateProductSubgroup(ctx context.Context, productsubgroup *entity.ProductSubGroup) error {
	return s.repo.Create(ctx, productsubgroup)
}

func (s *productSubgroupService) SelectallProductSubgroup(ctx context.Context) ([]*entity.ProductSubGroup, error) {

	productSubgroup, err := s.repo.SelectAllProductSubgroup(ctx)

	if err != nil {
		return nil, err
	}

	return productSubgroup, nil

}
