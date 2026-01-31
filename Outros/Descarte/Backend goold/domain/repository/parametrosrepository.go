package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type ParametrosRepository interface {
	SelectAllParametros(ctx context.Context) ([]*entity.Parametros, error)
	UpdateAllParametros(ctx context.Context, parametro *entity.Parametros) (*entity.Parametros, error)
}

type parametrosRepository struct {
	datastore *datastore.ParametrosDatastore
}

func NewParametrosRepository(ds *datastore.ParametrosDatastore) ParametrosRepository {
	return &parametrosRepository{
		datastore: ds,
	}
}

func (r *parametrosRepository) SelectAllParametros(ctx context.Context) ([]*entity.Parametros, error) {
	return r.datastore.GetParametros()
}

func (r *parametrosRepository) UpdateAllParametros(ctx context.Context, parametro *entity.Parametros) (*entity.Parametros, error) {
	return r.datastore.PostParametros(parametro)
}
