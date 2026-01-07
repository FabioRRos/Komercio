package datastore

import (
	"context"
	"fmt"

	dto "github.com/fabioros/Komercio/domain/DTO"
	"github.com/fabioros/Komercio/domain/entity"

	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ReportDatastore struct {
	Pool *pgxpool.Pool
}

func NewConReportDataStore(pool *pgxpool.Pool) *ReportDatastore {
	return &ReportDatastore{Pool: pool}
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

	rows, err := d.Pool.Query(context.Background(), query)

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

	row := d.Pool.QueryRow(context.Background(), query, id)

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

func (d *ReportDatastore) SelectMargemLucroVendas(ctx context.Context) ([]*dto.SaleItemReportDTO, error) {
	query := `SELECT
    -- Identificação da venda
    s.sale_id,
    s.sale_date,
    s.sale_time,

    -- Cliente e vendedor
    s.customer_id,
    s.seller_id,
    f.employeefullname AS seller_name,
    f.employeelogin    AS seller_login,

    -- Produto
    si.sale_item_id,
    si.product_id,
    si.product_name,
    si.barcode,

    -- Valores de venda
    si.unit_price      AS valor_unitario_venda,
    si.quantity        AS quantidade_vendida,
    si.total           AS valor_total_venda_produto,

    -- Valores de compra (CMV / FIFO)
    vcv.valor_compra_produto AS valor_total_compra_produto,

    -- Margem
    (si.total - vcv.valor_compra_produto) AS margem_produto,

    -- Totais da venda
    s.total_amount,
    s.discount_amount,
    s.final_amount,
    s.payment_method

FROM sales s

INNER JOIN sale_items si
    ON si.sale_id = s.sale_id

INNER JOIN valores_compra_venda vcv
    ON vcv.sale_id = s.sale_id
   AND vcv.product_id = si.product_id

INNER JOIN employees f   --  ajuste esse nome se necessário
    ON f.employeeid = s.seller_id

ORDER BY
    s.sale_date,
    s.sale_id,
    si.sale_item_id;`

	rows, err := d.Pool.Query(ctx, query)

	if err != nil {
		return nil, fmt.Errorf("Erro ao consultar o relatório")
	}

	defer rows.Close()

	var report []*dto.SaleItemReportDTO

	for rows.Next() {
		var r dto.SaleItemReportDTO
		err := rows.Scan(
			&r.SaleID,
			&r.SaleDate,
			&r.SaleTime,
			&r.CustomerID,
			&r.SellerID,
			&r.SellerName,
			&r.SellerLogin,
			&r.SaleItemID,
			&r.ProductID,
			&r.ProductName,
			&r.Barcode,
			&r.UnitPrice,
			&r.Quantity,
			&r.TotalSaleProduct,
			&r.TotalPurchaseProduct,
			&r.Margin,
			&r.TotalAmount,
			&r.DiscountAmount,
			&r.FinalAmount,
			&r.PaymentMethod,
		)

		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}

		report = append(report, &r)
	}
	if err := rows.Err(); err != nil {
		return nil, fmt.Errorf("erro durante iteração das linhas: %w", err)
	}
	return report, nil
}
