package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
)

type CupomService interface {
	GetCupom(ctx context.Context, id int) (*entity.CupomDTO, error)
}

func NewCupomService(
	saleReport ReportService,
	saleItemsService SaleItemsService,
) CupomService {
	return &cupomService{
		saleReport:       saleReport,
		saleItemsService: saleItemsService,
	}
}

type cupomService struct {
	saleReport       ReportService
	saleItemsService SaleItemsService
}

func (s *cupomService) GetCupom(ctx context.Context, id int) (*entity.CupomDTO, error) {
	saleReport, err := s.saleReport.SelectSalesReportbyId(ctx, id)
	if err != nil {
		return nil, err
	}

	saleItens, err := s.saleItemsService.GetItemsBySaleId(ctx, id)
	if err != nil {
		return nil, err
	}

	cupom := &entity.CupomDTO{
		Salereport: *saleReport,
		SaleItens:  saleItens,
	}

	return cupom, nil
}
