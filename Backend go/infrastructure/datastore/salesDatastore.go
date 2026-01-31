package datastore

import (
	"context"
	"fmt"
	"log"
	"strconv"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type SalesDatastore struct {
	Conn *pgx.Conn
}

// ################################################# Construtor
func NewSalesDataStore() *SalesDatastore {
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {

		log.Fatalf("Erro na conexão: %v", err)

	}

	return &SalesDatastore{Conn: conn}
}

// ################################################# Fechar conexão
func (d *SalesDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// ################################################# Criar venda (sem transação)
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
		RETURNING sale_id;
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

// ################################################# Criar venda (dentro de uma transação)
func (d *SalesDatastore) NewSaleTx(ctx context.Context, tx pgx.Tx, sales *entity.Sales) (int, error) {
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
		RETURNING sale_id;
	`

	var saleID int
	err := tx.QueryRow(ctx,
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
		return 0, fmt.Errorf("erro ao inserir a venda (Tx): %w", err)
	}

	return saleID, nil
}

// ################################################# DELETAR VENDA EM CASCATA

func (d *SalesDatastore) DeleteSaleCascade(ctx context.Context, saleID int) (err error) {
	tx, err := d.Conn.Begin(ctx)
	if err != nil {
		return err
	}

	// O defer garante que:
	// 1. Se der erro, faz Rollback.
	// 2. Se der Commit, o Rollback não faz nada (operação segura).
	defer tx.Rollback(ctx)

	var idTexto string = "Venda ID " + strconv.Itoa(saleID)

	// 1. Queries que usam apenas saleID ($1)
	queriesID := []string{
		`DELETE FROM forma_pagamento WHERE sale_id IN (SELECT movement_id FROM cash_movements WHERE sale_id = $1);`,
		`DELETE FROM cash_movements WHERE sale_id = $1;`,
		`DELETE FROM customer_transactions WHERE sale_id = $1;`,
		`DELETE FROM sale_items WHERE sale_id = $1;`,
	}

	for _, q := range queriesID {
		if _, err = tx.Exec(ctx, q, saleID); err != nil {
			return fmt.Errorf("erro: %w", err)
		}
	}

	// 2. Query que usa idTexto ($1) - Nota: no seu original era $2, aqui vira $1 desta chamada
	queryCaixa := `DELETE FROM caixa WHERE observations = $1;`
	if _, err = tx.Exec(ctx, queryCaixa, idTexto); err != nil {
		return fmt.Errorf("erro ao deletar caixa: %w", err)
	}

	// 3. Query final
	querySales := `DELETE FROM sales WHERE sale_id = $1;`
	if _, err = tx.Exec(ctx, querySales, saleID); err != nil {
		return fmt.Errorf("erro ao deletar venda: %w", err)
	}

	err = tx.Commit(ctx)
	if err != nil {
		return err
	}

	return nil
}
