package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type CustomertransactionDatastore struct {
	Conn *pgx.Conn
}

func NewCustomertransactionDatastore() *CustomertransactionDatastore {
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"
	conn, err := pgx.Connect(context.Background(), connStr)
	if err != nil {

		log.Fatalf("Erro na conexão: %v", err)

	}
	return &CustomertransactionDatastore{Conn: conn}
}

func (d *CustomertransactionDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

func (d *CustomertransactionDatastore) CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error {
	query := `insert into customer_transactions(
	sale_id,
	customer_id,
	origin_type,
	transaction_value,
	transaction_date,
	obs,
	seller,
	type_payment
	)VALUES($1,$2,$3,$4,$5,$6,$7,$8)`

	_, err := tx.Exec(ctx, query,
		transaction.Sale_id,     // id da venda OU do pagamento (serve para os dois)
		transaction.Customer_id, // id do cliente
		transaction.Origin_type, // tipo. Entrada, saida
		transaction.Transaction_value,
		transaction.Transaction_date,
		transaction.Obs,
		transaction.Seller,
		transaction.Type_payment,
	)

	if err != nil {
		return fmt.Errorf("DT - erro ao inserir movimentação do caixa (Tx): %w", err)

	}
	return nil
}

func (d *CustomertransactionDatastore) GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error) {

	query := `select * from customer_transactions`

	rows, err := d.Conn.Query(context.Background(), query)

	if err != nil {
		return nil, fmt.Errorf("DT1 - erro ao consultar transações: %w", err)
	}
	defer rows.Close()

	var transactions []*entity.CustomerTransaction

	for rows.Next() {
		var transaction entity.CustomerTransaction
		err := rows.Scan(
			&transaction.Id_transaction,
			&transaction.Sale_id,     // id da venda OU do pagamento (serve para os dois)
			&transaction.Customer_id, // id do cliente
			&transaction.Origin_type, // tipo. Entrada, saida
			&transaction.Transaction_value,
			&transaction.Transaction_date,
			&transaction.Obs,
			&transaction.Seller,
			&transaction.Type_payment,
		)
		if err != nil {
			return nil, fmt.Errorf("DT2 - erro ao ler linha da transação: %w", err)
		}
		transactions = append(transactions, &transaction)
	}
	return transactions, nil
}

func (d *CustomertransactionDatastore) GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error) {

	query := `select * from customer_transactions where customer_id = $1`

	rows, err := d.Conn.Query(context.Background(), query, idtransaction)

	if err != nil {
		return nil, fmt.Errorf("erro ao consultar transações: %w", err)
	}
	defer rows.Close()

	var transactions []*entity.CustomerTransaction

	for rows.Next() {
		var transaction entity.CustomerTransaction
		err := rows.Scan(
			&transaction.Id_transaction,
			&transaction.Sale_id,     // id da venda OU do pagamento (serve para os dois)
			&transaction.Customer_id, // id do cliente
			&transaction.Origin_type, // tipo. Entrada, saida
			&transaction.Transaction_value,
			&transaction.Transaction_date,
			&transaction.Obs,
			&transaction.Seller,
			&transaction.Type_payment,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha da transação: %w", err)
		}
		transactions = append(transactions, &transaction)
	}
	return transactions, nil
}
