package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type ProductGroupDatastore struct {
	Conn *pgx.Conn
}

func NewProductGroupDataStore() *ProductGroupDatastore {
	//connStr := "postgresql://postgres:postgres@68.211.176.125:5432/komercio?sslmode=disable"

	connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"
	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {
		log.Fatalf("Erro ao conectar ao banco: %v", err)
	}

	return &ProductGroupDatastore{Conn: conn}
}

func (d *ProductGroupDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// CREATE (PUT)
func (d *ProductGroupDatastore) CreateProducGroup(productGroup *entity.ProductGroup) error {
	query := `INSERT INTO product_group
	(group_id, group_name) Values ($1, $2)`

	_, err := d.Conn.Exec(context.Background(), query, productGroup.ProductGroup_id, productGroup.ProducGroup_name)

	if err != nil {
		return fmt.Errorf("Erro ao inserir grupo de produtos: %w", err)
	}

	return nil
}

// READ (GET)
func (d *ProductGroupDatastore) SelectAllProductGroup() ([]*entity.ProductGroup, error) {

	query := `Select * from product_group`

	rows, err := d.Conn.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("erro ao consultar o grupo de produtos %w", err)
	}

	defer rows.Close()

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
