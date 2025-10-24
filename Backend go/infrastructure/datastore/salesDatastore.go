package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type SalesDatastore struct {
	Conn *pgx.Conn
}

func NewSalesDataStore() *SalesDatastore {
	connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"

	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {
		log.Fatalf("Erro ao conectar ao banco: %v", err)
	}
	return &SalesDatastore{Conn: conn}
}

func (d *SalesDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// Salvar venda

func (d *SalesDatastore) NewSale(sales *entity.Sales) (int, error) {

	query := `
    INSERT INTO sales (
        customer_id,
        total_amount,
        discount_amount,
        final_amount,
        sale_date,
        sale_time,
        payment_method,
        seller_id,
        sale_notes
    )
    VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9)
    RETURNING sale_id
`

	var saleID int
	err := d.Conn.QueryRow(
		context.Background(),
		query,
		sales.CustomerId,
		sales.TotalAmount,
		sales.DiscountAmount,
		sales.FinalAmount,
		sales.SalesDate,
		sales.SalesHour,
		sales.PaymentMethod,
		sales.SellerId,
		sales.SaleNotes,
	).Scan(&saleID)

	if err != nil {
		return 0, fmt.Errorf("erro ao inserir a venda: %w", err)
	}

	return saleID, nil

}
