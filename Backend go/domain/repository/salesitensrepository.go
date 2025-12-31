package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
	"github.com/jackc/pgx/v5"
)

type SaleItemsRepository interface {
	CreateSaleItem(ctx context.Context, item *entity.SalesItens) error
	GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error)
	GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error)

	//Novo método: inserir item dentro de uma transação
	CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error
}

type saleItemsRepository struct {
	datastore *datastore.SaleItemsDatastore
}

func NewSaleItemsRepository(ds *datastore.SaleItemsDatastore) SaleItemsRepository {
	return &saleItemsRepository{
		datastore: ds,
	}
}

// =============================================================
// Inserir item fora da transação
func (r *saleItemsRepository) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {
	return r.datastore.CreateSaleItem(ctx, item)
}

// =============================================================
// Inserir item dentro de uma transação
func (r *saleItemsRepository) CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error {
	return r.datastore.CreateSaleItemTx(ctx, tx, item)
}

// =============================================================
// Buscar todos os itens
func (r *saleItemsRepository) GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error) {
	return r.datastore.GetAllSaleItems(ctx)
}

// =============================================================
// Buscar itens por ID da venda
func (r *saleItemsRepository) GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error) {
	return r.datastore.GetItemsBySaleId(ctx, saleId)
}
