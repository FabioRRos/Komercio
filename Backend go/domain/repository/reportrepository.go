package repository

import (
	"context"

	dto "github.com/fabioros/Komercio/domain/DTO"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ReportRepository interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
	SelectSaleReportById(ctx context.Context, id int) (*entity.Salereport, error)
	SelectMargemLucroVendas(ctx context.Context) ([]*dto.SaleItemReportDTO, error)
}

type reportRepository struct {
	datastore *datastore.ReportDatastore
}

func NewReportRepository(ds *datastore.ReportDatastore) ReportRepository {
	return &reportRepository{
		datastore: ds,
	}
}

func (r *reportRepository) SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error) {
	return r.datastore.SelectSalesReport()
}

func (r *reportRepository) SelectSaleReportById(ctx context.Context, id int) (*entity.Salereport, error) {
	return r.datastore.SelectSalesReportbyId(id)
}

func (r *reportRepository) SelectMargemLucroVendas(ctx context.Context) ([]*dto.SaleItemReportDTO, error) {
	return r.datastore.SelectMargemLucroVendas(ctx)
}
