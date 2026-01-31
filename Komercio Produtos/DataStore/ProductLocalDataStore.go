package datastore

import (
	"context"
	"fmt"

	entity "github.com/fabioros/komercio/Entity"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ProductLocalDataStore struct {
	Pool *pgxpool.Pool
}

func NewProductDataStore(pool *pgxpool.Pool) *ProductLocalDataStore {
	return &ProductLocalDataStore{
		Pool: pool,
	}
}

func (d *ProductLocalDataStore) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	query := `
		SELECT
			id,
			productname,
			productprice,
			productcodbar,
			productgroup,
			productsubgroup,
			status,
			productstock
		FROM products
	`

	rows, err := d.Pool.Query(ctx, query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar produtos: %w", err)
	}
	defer rows.Close()

	var products []*entity.Product

	for rows.Next() {
		var p entity.Product
		err := rows.Scan(
			&p.Id,
			&p.ProductName,
			&p.ProductPrice,
			&p.ProductCodBar,
			&p.ProductGroup,
			&p.ProductSubGroup,
			&p.ProductStatus,
			&p.ProductStock,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}
		products = append(products, &p)
	}

	if err := rows.Err(); err != nil {
		return nil, fmt.Errorf("erro durante iteração dos produtos: %w", err)
	}

	return products, nil
}

func (d *ProductLocalDataStore) UpdateAllProducts(ctx context.Context, produto *entity.PrecoCompra) error {
	query := `insert into valueproduct(
				codigobarras,
				valorcompra,
				quantidade,
				status,
				dataentrada,
				obs)
				values ($1, $2, $3, $4, $5, $6)`

	_, err := d.Pool.Exec(ctx, query,
		produto.CodigoBarras,
		produto.ValorCompra,
		produto.Quantidade,
		produto.Status,
		produto.DataEntrada,
		produto.Obs,
	)

	if err != nil {
		return fmt.Errorf("Erro ao adicionar o produto na tabela VALUEPRODUCT %w", err)
	}

	fmt.Println("Produto adicionado com sucesso ->", produto.Obs)

	return nil

}
