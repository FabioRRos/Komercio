package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ProductGroupDatastore struct {
	Pool *pgxpool.Pool
}

func NewProductGroupDataStore(pool *pgxpool.Pool) *ProductGroupDatastore {
	return &ProductGroupDatastore{Pool: pool}
}

// CREATE (POST)
func (d *ProductGroupDatastore) CreateProducGroup(productGroup *entity.ProductGroup) error {
	query := `INSERT INTO product_group
	(group_name) Values ($1)`

	_, err := d.Pool.Exec(context.Background(), query, productGroup.ProducGroup_name)

	if err != nil {
		return fmt.Errorf("Erro ao inserir grupo de produtos: %w", err)
	}

	return nil
}

// READ (GET)
func (d *ProductGroupDatastore) SelectAllProductGroup() ([]*entity.ProductGroup, error) {

	query := `Select * from product_group`

	rows, err := d.Pool.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("erro ao consultar o grupo de produtos %w", err)
	}

	var productGroup []*entity.ProductGroup

	for rows.Next() { // ESTOU AQUI!!!!!
		var pg entity.ProductGroup
		err := rows.Scan(
			&pg.ProductGroup_id,
			&pg.ProducGroup_name,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}
		productGroup = append(productGroup, &pg)
	}

	return productGroup, nil

}
