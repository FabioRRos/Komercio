package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type SalesService interface {
	CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error)
}

type salesService struct {
	repo repository.SalesRepository
}

func NewSalesService(repo repository.SalesRepository) SalesService {
	return &salesService{repo: repo}
}

func (s *salesService) CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error) {
	if sale != nil {
		return 0, errors.New("Venda não pode ser nula")
	}

	return s.repo.CreateNewSale(ctx, sale)
}
