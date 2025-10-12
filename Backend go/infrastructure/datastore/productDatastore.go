package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

// Esse cara fará gerenciamento das conexões e as operações relacionadas aos produtos
type ProductDatastore struct {
	Conn *pgx.Conn
}

//Será o cara repsonsavel por criar uma nova instância de productDataStore e conectar ao banco

func NewProductDataStore() *ProductDatastore {
	connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"

	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {
		log.Fatalf("Erro ao conectar ao banco: %v", err)
	}

	//fmt.Println("Conectado ao banco de dados com sucesso!")

	return &ProductDatastore{Conn: conn}
}

// Close encerrará a conexão com o banco de dados

func (d *ProductDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
		//	fmt.Println("Conexão com o banco encerrada")
	}
}

//Cria um novo produto no banco de dados.

func (d *ProductDatastore) CreateProduct(product *entity.Product) error {
	query := `
		INSERT INTO products 
		(ProductName, ProductPrice, ProductCodBar, ProductGroup, ProductSubGroup, ProductStock, status)
		VALUES ($1, $2, $3, $4, $5, $6, $7)`

	_, err := d.Conn.Exec(context.Background(), query, product.ProductName, product.ProductPrice, product.ProductCodBar, product.ProductGroup, product.ProductSubGroup, product.ProductStock, product.ProductStatus)

	if err != nil {
		return fmt.Errorf("erro ao inserir produto: %w", err)
	}
	//fmt.Println("Produto cadastrado com sucesso!")
	return nil

}

// select. Eu chamo o ponteiro de d (productDatastore) e retorno um slice de produto + um erro
func (d *ProductDatastore) SelectAllProducts() ([]*entity.Product, error) {
	query := `SELECT id, ProductName, ProductPrice, ProductCodBar, ProductGroup, ProductSubGroup, status, ProductStock FROM products`

	rows, err := d.Conn.Query(context.Background(), query)
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
			&p.ProductStatus, // ← corrigido
			&p.ProductStock,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}
		products = append(products, &p)
	}

	return products, nil
}
