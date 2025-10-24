package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type SalesRepository interface {
	CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error)
}

type salesRepository struct {
	datastore *datastore.SalesDatastore
}

// ################################################# SalesRepository da interface
func NewSalesRepository(ds *datastore.SalesDatastore) SalesRepository {
	return &salesRepository{
		datastore: ds,
	}
}

func (r *salesRepository) CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error) {
	return r.datastore.NewSale(sale)
}
