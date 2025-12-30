package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type ReportDatastore struct {
	Conn *pgx.Conn
}

func NewConReportDataStore() *ReportDatastore {
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {

		log.Fatalf("Erro na conexão: %v", err)

	}
	return &ReportDatastore{Conn: conn}
}

func (d *ReportDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

//Querie melhorada
//Verificar depois a utilização de todas as tabelas.

func (d *ReportDatastore) SelectSalesReport() ([]*entity.Salereport, error) {
	query := `
SELECT
    s.sale_id,
    CONCAT(c.customerfirstname, ' ', c.customerlastname) AS customer_name,
    c.customerdocument AS customer_document,
    e.employeelogin AS seller_name,
    s.total_amount,
    s.discount_amount,
    s.final_amount,
    s.sale_date,
    s.sale_time,
    s.payment_method,
    s.sale_notes
FROM sales AS s
LEFT JOIN customers AS c ON c.customerid = s.customer_id
LEFT JOIN employees AS e ON e.employeeid = s.seller_id
ORDER BY s.sale_id DESC;
`

	rows, err := d.Conn.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("Erro ao consultar o relatório")
	}

	var report []*entity.Salereport

	for rows.Next() {
		var r entity.Salereport
		err := rows.Scan(
			&r.SaleId,
			&r.CustomerName,
			&r.CustomerDocument,
			&r.SallerName,
			&r.TotalAmount,
			&r.DiscountAmount,
			&r.FinalAmout,
			&r.SaleDate,
			&r.SaleTime,
			&r.PaymentMethod,
			&r.SaleNotes,
		)

		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}

		report = append(report, &r)
	}

	return report, nil

}

func (d *ReportDatastore) SelectSalesReportbyId(id int) (*entity.Salereport, error) {
	query := `
	SELECT 
		s.sale_id,
		CONCAT(c.customerfirstname, ' ', c.customerlastname) AS customer_name,
		c.customerdocument AS customer_document,
		e.employeefullname AS seller_name,
		s.total_amount,
		s.discount_amount,
		s.final_amount,
		s.sale_date,
		s.sale_time,
		s.payment_method,
		s.sale_notes
	FROM sales s
	LEFT JOIN customers c ON s.customer_id = c.customerid
	LEFT JOIN employees e ON s.seller_id = e.employeeid
	WHERE s.sale_id = $1
	ORDER BY s.sale_id DESC`

	row := d.Conn.QueryRow(context.Background(), query, id)

	var r entity.Salereport

	err := row.Scan(
		&r.SaleId,
		&r.CustomerName,
		&r.CustomerDocument,
		&r.SallerName,
		&r.TotalAmount,
		&r.DiscountAmount,
		&r.FinalAmout,
		&r.SaleDate,
		&r.SaleTime,
		&r.PaymentMethod,
		&r.SaleNotes,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("nenhuma venda encontrada para o ID %d", id)
		}
		return nil, fmt.Errorf("erro ao consultar relatório: %w", err)
	}

	return &r, nil
}
