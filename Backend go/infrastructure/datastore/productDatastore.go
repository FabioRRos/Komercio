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
		(ProductName, ProductPrice, ProductCodBar, ProductGroup, ProductSubGroup, ProductStock)
		VALUES ($1, $2, $3, $4, $5, $6)`

	_, err := d.Conn.Exec(context.Background(), query, product.ProductName, product.ProductPrice, product.ProductCodBar, product.ProductGroup, product.ProductSubGroup, product.ProductStock)

	if err != nil {
		return fmt.Errorf("erro ao inserir produto: %w", err)
	}
	//fmt.Println("Produto cadastrado com sucesso!")
	return nil

}
