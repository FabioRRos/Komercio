package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

type SalesRepository interface {
	CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error)

	// adicionados, mas ainda não dependem do datastore
	BeginTransaction(ctx context.Context) (pgx.Tx, error)
	CreateNewSaleTx(ctx context.Context, tx pgx.Tx, sale *entity.Sales) (int, error)
}

type salesRepository struct {
	datastore *datastore.SalesDatastore
}

// ################################################# Construtor
func NewSalesRepository(ds *datastore.SalesDatastore) SalesRepository {
	return &salesRepository{
		datastore: ds,
	}
}

// ################################################# Criação de venda (normal)
func (r *salesRepository) CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error) {
	return r.datastore.NewSale(sale)
}

// ################################################# Início da transação
func (r *salesRepository) BeginTransaction(ctx context.Context) (pgx.Tx, error) {

	return r.datastore.Conn.Begin(ctx)
}

// ################################################# Criação da venda dentro da transação
func (r *salesRepository) CreateNewSaleTx(ctx context.Context, tx pgx.Tx, sale *entity.Sales) (int, error) {
	return r.datastore.NewSaleTx(ctx, tx, sale)
}
