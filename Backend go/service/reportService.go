package service

import (
	"context"

	dto "github.com/fabioros/Komercio/domain/DTO"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ReportService interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
	SelectSalesReportbyId(ctx context.Context, id int) (*entity.Salereport, error)
	SelectMargemLucroVendas(ctx context.Context) ([]*dto.SaleItemReportDTO, error)
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

func (s *reportService) SelectSalesReportbyId(ctx context.Context, id int) (*entity.Salereport, error) {
	salereport, err := s.repo.SelectSaleReportById(ctx, id)
	if err != nil {
		return nil, err
	}

	return salereport, err
}

func (s *reportService) SelectMargemLucroVendas(ctx context.Context) ([]*dto.SaleItemReportDTO, error) {
	salereport, err := s.repo.SelectMargemLucroVendas(ctx)
	if err != nil {
		return nil, err
	}

	return salereport, nil

}
