package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

type CustomertransactionRepository interface {
	CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error
	CreateTransaction(ctx context.Context, transaction *entity.CustomerTransaction) error

	GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error)
	GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error)
}

type customertransactionRepository struct {
	datastore *datastore.CustomertransactionDatastore
}

func NewCustomertransactionRepository(ds *datastore.CustomertransactionDatastore) CustomertransactionRepository {
	return &customertransactionRepository{
		datastore: ds,
	}
}

func (r *customertransactionRepository) CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error {
	return r.datastore.CreateTransactionTX(ctx, tx, transaction)
}
func (r *customertransactionRepository) CreateTransaction(ctx context.Context, transaction *entity.CustomerTransaction) error {
	return r.datastore.CreateTransaction(ctx, transaction)
}

func (r *customertransactionRepository) GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error) {
	return r.datastore.GETTransaction(ctx)
}

func (r *customertransactionRepository) GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error) {
	return r.datastore.GETTransactionById(ctx, idtransaction)
}
