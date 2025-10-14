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
		(productname, productprice, productcodbar, productgroup, productsubgroup, productstock, status)
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

// select. Eu chamo o ponteiro de d (productDatastore) e retorno um slice de produto + um erro
func (d *ProductDatastore) SelectProductById(id int) (*entity.Product, error) {
	query := `
		SELECT 
			id, ProductName, ProductPrice, ProductCodBar, 
			ProductGroup, ProductSubGroup, status, ProductStock 
		FROM products 
		WHERE id = $1
	`

	var p entity.Product

	err := d.Conn.QueryRow(context.Background(), query, id).Scan(
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
		// caso o produto não exista
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("produto com id %d não encontrado", id)
		}
		// outro erro qualquer (banco, conexão, etc.)
		return nil, fmt.Errorf("erro ao buscar produto: %w", err)
	}

	return &p, nil
}

func (d *ProductDatastore) UpdateProduct(product *entity.Product) (*entity.Product, error) {
	query := `
		UPDATE products SET
			productname = $2,
			productprice = $3,
			productgroup = $4,
			productsubgroup = $5,
			productstock = $6,
			status = $7
		WHERE id = $1
		RETURNING id, productname, productprice, productcodbar, 
		          productgroup, productsubgroup, status, productstock
	`

	var p entity.Product

	err := d.Conn.QueryRow(context.Background(), query,
		product.Id,
		product.ProductName,
		product.ProductPrice,
		product.ProductGroup,
		product.ProductSubGroup,
		product.ProductStock,
		product.ProductStatus,
	).Scan(
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
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("produto com id %d não encontrado", product.Id)
		}
		return nil, fmt.Errorf("erro ao atualizar produto: %w", err)
	}

	return &p, nil
}

func (d *ProductDatastore) DeactivateProduct(id int) error {
	query := `
		UPDATE products
		SET status = false
		WHERE id = $1
	`

	_, err := d.Conn.Exec(context.Background(), query, id)
	if err != nil {
		return fmt.Errorf("erro ao desativar produto com id %d: %w", id, err)
	}

	return nil

}
