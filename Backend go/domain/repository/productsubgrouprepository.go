package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ProductSubgroupRepository interface {
	Create(ctx context.Context, productsubgroup *entity.ProductSubGroup) error
	SelectAllProductSubgroup(ctx context.Context) ([]*entity.ProductSubGroup, error)
}

type productSubgroupRepository struct {
	datastore *datastore.ProductSubgroupDatastore
}

func NewProductSubgroupRepository(ds *datastore.ProductSubgroupDatastore) ProductSubgroupRepository {
	return &productSubgroupRepository{
		datastore: ds,
	}

}

func (r *productSubgroupRepository) Create(ctx context.Context, productsubgroup *entity.ProductSubGroup) error {
	return r.datastore.CreateProducGroup(productsubgroup)
}

func (r *productSubgroupRepository) SelectAllProductSubgroup(ctx context.Context) ([]*entity.ProductSubGroup, error) {
	return r.datastore.SelectAllProductSubgroup()
}
