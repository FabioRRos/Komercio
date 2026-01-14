package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

type CaixaRepository interface {
	CaixaChange(ctx context.Context, caixa *entity.Caixa) error
	CaixaChangeTX(ctx context.Context, tx pgx.Tx, caixa *entity.Caixa) error
	GetCaixa(ctx context.Context) ([]*entity.Caixa, error)
}

type caixaRepository struct {
	datastore *datastore.CaixaDatastore
}

func NewCaixaRepository(ds *datastore.CaixaDatastore) CaixaRepository {
	return &caixaRepository{
		datastore: ds,
	}
}

func (r *caixaRepository) CaixaChangeTX(ctx context.Context, tx pgx.Tx, caixa *entity.Caixa) error {
	return r.datastore.CaixaChangeTX(ctx, tx, caixa)
}

func (r *caixaRepository) CaixaChange(ctx context.Context, caixa *entity.Caixa) error {
	return r.datastore.CaixaChange(ctx, caixa)
}

func (r *caixaRepository) GetCaixa(ctx context.Context) ([]*entity.Caixa, error) {
	return r.datastore.GetCaixa(ctx)
}
