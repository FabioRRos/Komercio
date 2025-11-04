package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ReportRepository interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
	SelectSaleReportById(ctx context.Context, id int) (*entity.Salereport, error)
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
