package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ReportRepository interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
	SelectSaleReportById(ctx context.Context, id int) (*entity.Salereport, error)
	SelectSales(ctx context.Context) ([]*entity.Sales, error)
	SelectItensSale(ctx context.Context, idVenda int) ([]*entity.SalesItens, error)
	SelectPrecoItensVenda(ctx context.Context, idVenda int) ([]*entity.DifValue, error)
	SelectActiveEmployeeNames(ctx context.Context) ([]*dto.EmployeeSimple, error)
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

func (r *reportRepository) SelectSales(ctx context.Context) ([]*entity.Sales, error) {
	return r.datastore.SelectSales(ctx)
}
func (r *reportRepository) SelectItensSale(ctx context.Context, idVenda int) ([]*entity.SalesItens, error) {
	return r.datastore.SelectItensSale(ctx, idVenda)
}

func (r *reportRepository) SelectPrecoItensVenda(ctx context.Context, idVenda int) ([]*entity.DifValue, error) {
	return r.datastore.SelectPrecoItensVenda(ctx, idVenda)
}

func (r *reportRepository) SelectActiveEmployeeNames(ctx context.Context) ([]*dto.EmployeeSimple, error) {
	return r.datastore.SelectActiveEmployeeNames(ctx)
}
