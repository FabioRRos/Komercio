package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ProductSubgroupDatastore struct {
	Pool *pgxpool.Pool
}

func NewProductSubgroupDatastore(pool *pgxpool.Pool) *ProductSubgroupDatastore {

	return &ProductSubgroupDatastore{Pool: pool}
}

// CREATE (PUT)
func (d *ProductSubgroupDatastore) CreateProducGroup(ProductSubgroup *entity.ProductSubGroup) error {
	query := `INSERT INTO product_subgroup
	(subgroup_name,product_group_id) Values ($1,$2)`

	_, err := d.Pool.Exec(context.Background(), query, ProductSubgroup.ProducSubGroup_name, ProductSubgroup.Product_group_id)

	if err != nil {
		return fmt.Errorf("Erro ao inserir subgrupo de produtos: %w", err)
	}

	return nil
}

// READ (GET)
func (d *ProductSubgroupDatastore) SelectAllProductSubgroup() ([]*entity.ProductSubGroup, error) {

	query := `Select * from product_subgroup`

	rows, err := d.Pool.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("erro ao consultar o subgrupo de produtos %w", err)
	}

	var ProductSubgroup []*entity.ProductSubGroup

	for rows.Next() { // ESTOU AQUI!!!!!
		var pg entity.ProductSubGroup
		err := rows.Scan(
			&pg.ProductSubGroup_id,
			&pg.ProducSubGroup_name,
			&pg.Product_group_id,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto:\n %w", err)
		}

		ProductSubgroup = append(ProductSubgroup, &pg)
	}

	return ProductSubgroup, nil

}
