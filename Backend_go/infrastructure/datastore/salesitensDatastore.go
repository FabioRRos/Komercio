package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

// Estrutura base que mantém a conexão ativa com o banco de dados
type SaleItemsDatastore struct {
	Pool *pgxpool.Pool
}

// Função construtora que cria uma nova instância de SaleItemsDatastore
func NewSaleItemsDatastore(pool *pgxpool.Pool) *SaleItemsDatastore {

	return &SaleItemsDatastore{Pool: pool}
}

// ################################################# Inserir item de venda (sem transação)
func (d *SaleItemsDatastore) CreateSaleItem(ctx context.Context, item *entity.SalesItens) error {
	query := `
		INSERT INTO sale_items (
			sale_id,
			product_id,
			product_name,
			barcode,
			unit_price,
			quantity,
			total
		) VALUES ($1, $2, $3, $4, $5, $6, $7)
	`

	_, err := d.Pool.Exec(ctx, query,
		item.SaleId,
		item.ProductId,
		item.ProductName,
		item.Barcode,
		item.UnitPrice,
		item.Quantity,
		item.Total,
	)
	if err != nil {
		return fmt.Errorf("erro ao inserir item da venda: %w", err)
	}

	return nil
}

// ################################################# Inserir item de venda (dentro de uma transação)
func (d *SaleItemsDatastore) CreateSaleItemTx(ctx context.Context, tx pgx.Tx, item *entity.SalesItens) error {
	query := `
		INSERT INTO sale_items (
			sale_id,
			product_id,
			product_name,
			barcode,
			unit_price,
			quantity,
			total
		) VALUES ($1, $2, $3, $4, $5, $6, $7)
	`

	_, err := tx.Exec(ctx, query,
		item.SaleId,
		item.ProductId,
		item.ProductName,
		item.Barcode,
		item.UnitPrice,
		item.Quantity,
		item.Total,
	)
	if err != nil {
		return fmt.Errorf("erro ao inserir item da venda (Tx): %w", err)
	}

	return nil
}

// ################################################# Buscar todos os itens de venda
func (d *SaleItemsDatastore) GetAllSaleItems(ctx context.Context) ([]*entity.SalesItens, error) {
	query := `SELECT sale_item_id, sale_id, product_id, product_name, barcode, unit_price, quantity, total FROM sale_items`

	rows, err := d.Pool.Query(ctx, query)
	if err != nil {
		return nil, fmt.Errorf("erro ao buscar itens da venda: %w", err)
	}

	var items []*entity.SalesItens

	for rows.Next() {
		var i entity.SalesItens
		err := rows.Scan(
			&i.SaleItemId,
			&i.SaleId,
			&i.ProductId,
			&i.ProductName,
			&i.Barcode,
			&i.UnitPrice,
			&i.Quantity,
			&i.Total,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do item da venda: %w", err)
		}
		items = append(items, &i)
	}

	return items, nil
}

// ################################################# Buscar itens de venda por ID de venda
func (d *SaleItemsDatastore) GetItemsBySaleId(ctx context.Context, saleId int) ([]*entity.SalesItens, error) {
	query := `
		SELECT sale_item_id, sale_id, product_id, product_name, barcode, unit_price, quantity, total
		FROM sale_items
		WHERE sale_id = $1
	`

	rows, err := d.Pool.Query(ctx, query, saleId)
	if err != nil {
		return nil, fmt.Errorf("erro ao buscar itens da venda (sale_id=%d): %w", saleId, err)
	}

	var items []*entity.SalesItens

	for rows.Next() {
		var i entity.SalesItens
		err := rows.Scan(
			&i.SaleItemId,
			&i.SaleId,
			&i.ProductId,
			&i.ProductName,
			&i.Barcode,
			&i.UnitPrice,
			&i.Quantity,
			&i.Total,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler item da venda (sale_id=%d): %w", saleId, err)
		}
		items = append(items, &i)
	}

	return items, nil
}
