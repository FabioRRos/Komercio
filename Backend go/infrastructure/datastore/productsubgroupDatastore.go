package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type ProductSubgroupDatastore struct {
	Conn *pgx.Conn
}

func NewProductSubgroupDatastore() *ProductSubgroupDatastore {
	//connStrProd := "postgresql://postgres:postgres@68.211.176.125:5432/komercio?sslmode=disable"
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"

	//connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	//connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"
	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {

		log.Fatalf("Erro na conexão: %v", err)

	}

	return &ProductSubgroupDatastore{Conn: conn}
}

func (d *ProductSubgroupDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// CREATE (PUT)
func (d *ProductSubgroupDatastore) CreateProducGroup(ProductSubgroup *entity.ProductSubGroup) error {
	query := `INSERT INTO product_subgroup
	(subgroup_id, subgroup_name) Values ($1, $2)`

	_, err := d.Conn.Exec(context.Background(), query, ProductSubgroup.ProductSubGroup_id, ProductSubgroup.ProducSubGroup_name)

	if err != nil {
		return fmt.Errorf("Erro ao inserir subgrupo de produtos: %w", err)
	}

	return nil
}

// READ (GET)
func (d *ProductSubgroupDatastore) SelectAllProductSubgroup() ([]*entity.ProductSubGroup, error) {

	query := `Select * from product_subgroup`

	rows, err := d.Conn.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("erro ao consultar o subgrupo de produtos %w", err)
	}

	defer rows.Close()

	var ProductSubgroup []*entity.ProductSubGroup

	for rows.Next() { // ESTOU AQUI!!!!!
		var pg entity.ProductSubGroup
		err := rows.Scan(
			&pg.ProductSubGroup_id,
			&pg.ProducSubGroup_name,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}
		ProductSubgroup = append(ProductSubgroup, &pg)
	}

	return ProductSubgroup, nil

}
