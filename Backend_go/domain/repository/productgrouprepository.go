package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ProductGroupRepository interface {
	Create(ctx context.Context, productgroup *entity.ProductGroup) error
	SelectAllProductGroup(ctx context.Context) ([]*entity.ProductGroup, error)
}

type productGroupRepository struct {
	datastore *datastore.ProductGroupDatastore
}

func NewProductGroupRepository(ds *datastore.ProductGroupDatastore) ProductGroupRepository {
	return &productGroupRepository{
		datastore: ds,
	}

}

func (r *productGroupRepository) Create(ctx context.Context, productgroup *entity.ProductGroup) error {
	return r.datastore.CreateProducGroup(productgroup)
}

func (r *productGroupRepository) SelectAllProductGroup(ctx context.Context) ([]*entity.ProductGroup, error) {
	return r.datastore.SelectAllProductGroup()
}
