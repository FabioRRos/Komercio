package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/dto"
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

// ETAPA 1 - PEGAR A LISTA DE VENDAS
func (d *ReportDatastore) SelectSales(ctx context.Context) ([]*entity.Sales, error) {

	query := `select * from sales`
	rows, err := d.Pool.Query(ctx, query)
	if err != nil {
		return nil, fmt.Errorf("Erro ao consultar as vendas")
	}
	var lista []*entity.Sales
	for rows.Next() {
		var p entity.Sales
		err := rows.Scan(
			&p.SalesId,
			&p.CustomerId,
			&p.TotalAmount,
			&p.DiscountAmount,
			&p.FinalAmount,
			&p.SalesDate,
			&p.SalesHour,
			&p.PaymentMethod,
			&p.SellerId,
			&p.SaleNotes,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha de vendas: %w", err)
		}
		lista = append(lista, &p)
	}

	return lista, nil
}

// ETAPA 2 - PEGAR A LISTA DE ITENS DA VENDA

func (d *ReportDatastore) SelectItensSale(ctx context.Context, idVenda int) ([]*entity.SalesItens, error) {
	query := `select * from sale_items si where si.sale_id  = $1`

	rows, err := d.Pool.Query(ctx, query, idVenda)

	if err != nil {
		return nil, fmt.Errorf("Erro ao consultar os itens")
	}
	var lista []*entity.SalesItens
	for rows.Next() {
		var p entity.SalesItens
		err := rows.Scan(
			&p.SaleItemId,
			&p.SaleId,
			&p.ProductId,
			&p.ProductName,
			&p.Barcode,
			&p.UnitPrice,
			&p.Quantity,
			&p.Total,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha dos itens da vendas: %w", err)
		}
		lista = append(lista, &p)
	}
	return lista, nil
}

///Etapa 3 - valores de compra dos produtos

func (d *ReportDatastore) SelectPrecoItensVenda(ctx context.Context, idVenda int) ([]*entity.DifValue, error) {
	query := `select * from valores_compra_venda bp where bp.sale_id = $1`

	rows, err := d.Pool.Query(ctx, query, idVenda)

	if err != nil {
		return nil, fmt.Errorf("Erro ao consultar os itens")
	}
	var lista []*entity.DifValue
	for rows.Next() {
		var p entity.DifValue
		err := rows.Scan(
			&p.Id_Valores,
			&p.Sale_id,
			&p.PrecoVenda,
			&p.PrecoCompra,
			&p.ProdictId,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha preco de compra dos itens da venda: %w", err)
		}
		lista = append(lista, &p)
	}
	return lista, nil
}

///Etapa 4 - Nome do vendedor

func (d *ReportDatastore) SelectActiveEmployeeNames(ctx context.Context) ([]*dto.EmployeeSimple, error) {
	query := `
		SELECT
			EmployeeID,
			EmployeeFullName
		FROM employees
		WHERE EmployeeStatus = true
	`

	rows, err := d.Pool.Query(ctx, query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar funcionários ativos: %w", err)
	}
	defer rows.Close()

	var lista []*dto.EmployeeSimple

	for rows.Next() {
		var e dto.EmployeeSimple
		if err := rows.Scan(
			&e.ID,
			&e.Name,
		); err != nil {
			return nil, fmt.Errorf("erro ao ler funcionário: %w", err)
		}
		lista = append(lista, &e)
	}

	return lista, nil
}
