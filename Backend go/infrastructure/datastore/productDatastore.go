package datastore

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ProductDatastore struct {
	Pool *pgxpool.Pool
}

func NewProductDataStore(pool *pgxpool.Pool) *ProductDatastore {
	return &ProductDatastore{
		Pool: pool,
	}
}

func (d *ProductDatastore) CreateProduct(product *entity.Product) error {
	query := `
		INSERT INTO products 
		(productname, productprice, productcodbar, productgroup, productsubgroup, productstock, status)
		VALUES ($1, $2, $3, $4, $5, $6, $7)
	`

	_, err := d.Pool.Exec(
		context.Background(),
		query,
		product.ProductName,
		product.ProductPrice,
		product.ProductCodBar,
		product.ProductGroup,
		product.ProductSubGroup,
		product.ProductStock,
		product.ProductStatus,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir produto: %w", err)
	}

	return nil
}

func (d *ProductDatastore) CreateProductDescarte(productDescarte *entity.ProducrtDescarte) error {
	query := `
		INSERT INTO baixa_produtos (id_product, id_funcionario, justificativa)
		SELECT 
			p.id,
			$1,
			$2
		FROM products p
		WHERE p.productcodbar = $3
	`

	cmdTag, err := d.Pool.Exec(
		context.Background(),
		query,
		productDescarte.Id_funcionario,
		productDescarte.Justificativa,
		productDescarte.CodBarProduto,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir descarte: %w", err)
	}

	if cmdTag.RowsAffected() == 0 {
		return errors.New("produto não encontrado para o código de barras informado")
	}

	return nil
}

func (d *ProductDatastore) SelectAllProducts() ([]*entity.Product, error) {
	query := `
		SELECT id, productname, productprice, productcodbar,
		       productgroup, productsubgroup, status, productstock
		FROM products
	`

	rows, err := d.Pool.Query(context.Background(), query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar produtos: %w", err)
	}

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

	return products, nil
}

func (d *ProductDatastore) SelectProductById(id int) (*entity.Product, error) {
	query := `
		SELECT id, productname, productprice, productcodbar,
		       productgroup, productsubgroup, status, productstock
		FROM products
		WHERE id = $1
	`

	var p entity.Product

	err := d.Pool.QueryRow(context.Background(), query, id).Scan(
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
			return nil, fmt.Errorf("produto com id %d não encontrado", id)
		}
		return nil, fmt.Errorf("erro ao buscar produto: %w", err)
	}

	return &p, nil
}

func (d *ProductDatastore) SelectProductByCodBar(productCodBar string) (*entity.Product, error) {
	query := `
		SELECT id, productname, productprice, productcodbar,
		       productgroup, productsubgroup, status, productstock
		FROM products
		WHERE productcodbar = $1
	`

	var p entity.Product

	err := d.Pool.QueryRow(context.Background(), query, productCodBar).Scan(
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
			return nil, fmt.Errorf("produto não encontrado")
		}
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

	err := d.Pool.QueryRow(
		context.Background(),
		query,
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
			return nil, fmt.Errorf("produto não encontrado")
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

	_, err := d.Pool.Exec(context.Background(), query, id)
	if err != nil {
		return fmt.Errorf("erro ao desativar produto: %w", err)
	}

	return nil
}

func (d *ProductDatastore) UpdateProductOutputStock(productcodbar string) error {
	query := `
		UPDATE products
		SET productstock = productstock - 1
		WHERE productcodbar = $1
		  AND productstock > 0
	`

	cmdTag, err := d.Pool.Exec(context.Background(), query, productcodbar)
	if err != nil {
		return fmt.Errorf("erro ao atualizar estoque: %w", err)
	}

	if cmdTag.RowsAffected() == 0 {
		return errors.New("produto não encontrado ou estoque insuficiente")
	}

	return nil
}

func (d *ProductDatastore) UpdateProductOutputStockTX(
	ctx context.Context,
	tx pgx.Tx,
	productcodbar string,
	ProductStock int,
) error {

	query := `
		UPDATE products SET
			productstock = productstock - $2
		WHERE productcodbar = $1
	`

	_, err := tx.Exec(ctx, query, productcodbar, ProductStock)
	if err != nil {
		return fmt.Errorf("erro ao atualizar estoque (TX): %w", err)
	}

	return nil
}

type ProductCodBarQuantity struct {
	CodBar   string
	Quantity int
}

func (d *ProductDatastore) GetCodbarBySaleId(saleId int) ([]*ProductCodBarQuantity, error) {
	query := `select barcode,quantity from sale_items where sale_id  = $1`

	rows, err := d.Pool.Query(context.Background(), query, saleId)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar codbars: %w", err)
	}
	var codbars []*ProductCodBarQuantity

	for rows.Next() {
		var code string
		var quantity int
		err := rows.Scan(&code, &quantity)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler codbar: %w", err)
		}
		codbars = append(codbars, &ProductCodBarQuantity{CodBar: code, Quantity: quantity})
	}
	return codbars, nil

}

func (d *ProductDatastore) SelectProductSettings() ([]*entity.ProductNotification, error) {
	query := `
		SELECT 
			p.id,
			p.productname,
			pss.min_stock,
			pss.notify_enabled
		FROM product_stock_settings pss
		JOIN products p ON pss.product_id = p.id
	`

	rows, err := d.Pool.Query(context.Background(), query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar notificações: %w", err)
	}

	var products []*entity.ProductNotification

	for rows.Next() {
		var p entity.ProductNotification
		err := rows.Scan(
			&p.Id_productNotification,
			&p.Productname,
			&p.Productstock,
			&p.Notify_enabled,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler notificação: %w", err)
		}
		products = append(products, &p)
	}

	return products, nil
}

func (d *ProductDatastore) UpdateProductNotification(
	ctx context.Context,
	productList []*entity.ProductNotification,
) error {

	query := `
		UPDATE product_stock_settings
		SET min_stock = $1,
		    notify_enabled = $2
		WHERE product_id = $3
	`

	for _, k := range productList {

		cmdTag, err := d.Pool.Exec(
			ctx,
			query,
			k.Productstock,
			k.Notify_enabled,
			k.Id_productNotification,
		)

		if err != nil {
			return fmt.Errorf("erro ao atualizar %s: %w", k.Productname, err)
		}

		if cmdTag.RowsAffected() == 0 {
			return fmt.Errorf("nenhuma linha afetada para %s", k.Productname)
		}
	}

	return nil

}

func (d *ProductDatastore) UpdateProductInputStock(
	productCodBar string,
	quantidade int,
) (*entity.Product, error) {

	query := `
		UPDATE products
		SET productstock = productstock + $2
		WHERE productcodbar = $1
		RETURNING 
			id, productname, productprice, productcodbar,
			productgroup, productsubgroup, status, productstock
	`

	var p entity.Product

	err := d.Pool.QueryRow(
		context.Background(),
		query,
		productCodBar,
		quantidade,
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
			return nil, fmt.Errorf("produto não encontrado para o código %s", productCodBar)
		}
		return nil, fmt.Errorf("erro ao dar entrada no estoque: %w", err)
	}

	return &p, nil
}
