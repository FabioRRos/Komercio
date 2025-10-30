package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ReportService interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
}

type reportService struct {
	repo repository.ReportRepository
}

func NewSaleReportService(repo repository.ReportRepository) ReportService {
	return &reportService{repo: repo}
}

func (s *reportService) SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error) {
	salereport, err := s.repo.SelectSaleReport(ctx)
	if err != nil {
		return nil, err
	}

	return salereport, err
}
