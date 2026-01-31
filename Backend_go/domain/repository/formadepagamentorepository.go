package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

type FormaPagamentoRepository interface {
	CreateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) error
	CreateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) error
	UpdateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error)
	UpdateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error)
	ReadFormaPagamentoById(ctx context.Context, id int) (*entity.FormaPagamento, error)
	ReadAllFormaPagamento(ctx context.Context) ([]*entity.FormaPagamento, error)
	DeleteFormaPagamentoById(ctx context.Context, id int) error
}

type formaPagamentoRepository struct {
	datastore *datastore.FormaPagamentoDatastore
}

func NewFormaPagamentoRepository(ds *datastore.FormaPagamentoDatastore) FormaPagamentoRepository {
	return &formaPagamentoRepository{
		datastore: ds,
	}
}

func (r *formaPagamentoRepository) CreateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) error {
	return r.datastore.CreateFormaPagamento(ctx, formaPagamento)
}
func (r *formaPagamentoRepository) CreateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) error {
	return r.datastore.CreateFormaPagamentoTX(ctx, tx, formaPagamento)
}
func (r *formaPagamentoRepository) UpdateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	return r.datastore.UpdateFormaPagamento(ctx, formaPagamento)
}
func (r *formaPagamentoRepository) UpdateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	return r.datastore.UpdateFormaPagamentoTX(ctx, tx, formaPagamento)
}
func (r *formaPagamentoRepository) ReadFormaPagamentoById(ctx context.Context, id int) (*entity.FormaPagamento, error) {
	return r.datastore.ReadFormaPagamentoById(ctx, id)
}
func (r *formaPagamentoRepository) ReadAllFormaPagamento(ctx context.Context) ([]*entity.FormaPagamento, error) {
	return r.datastore.ReadAllFormaPagamento(ctx)
}
func (r *formaPagamentoRepository) DeleteFormaPagamentoById(ctx context.Context, id int) error {
	return r.datastore.DeleteFormaPagamentoById(ctx, id)
}
