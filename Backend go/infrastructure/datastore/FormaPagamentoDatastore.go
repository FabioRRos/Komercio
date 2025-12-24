package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type FormaPagamentoDatastore struct {
	Conn *pgx.Conn
}

func NewFormaPagamentoDatastore() *FormaPagamentoDatastore {
	connStr := "postgresql://postgres:postgres@localhost:5432/komercio?sslmode=disable"

	conn, err := pgx.Connect(context.Background(), connStr)

	if err != nil {
		log.Fatalf("Erro na conexão: %v", err)
	}
	return &FormaPagamentoDatastore{Conn: conn}
}

func (d *FormaPagamentoDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

// ################################################# CREATE forma de pagamento (sem transação)

func (d *FormaPagamentoDatastore) CreateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) error {
	query := `insert into forma_pagamento 
	(sale_id,forma_de_pagamento, valor_pago, data_pagamento)
values 
($1, $2, $3, $4)`
	_, err := d.Conn.Exec(ctx, query,
		formaPagamento.Sale_id,
		formaPagamento.Forma_de_pagamento,
		formaPagamento.Valor_pago,
		formaPagamento.Data_pagamento,
	)

	if err != nil {
		log.Printf("Erro ao inserir forma de pagamento: %v", err)
	}
	return err
}

// ################################################# CREATE forma de pagamento TX (dentro de uma transação)

func (d *FormaPagamentoDatastore) CreateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) error {
	query := `insert into forma_pagamento 
	(sale_id,forma_de_pagamento, valor_pago, data_pagamento)
values 
($1, $2, $3, $4)`
	_, err := tx.Exec(ctx, query,
		formaPagamento.Sale_id,
		formaPagamento.Forma_de_pagamento,
		formaPagamento.Valor_pago,
		formaPagamento.Data_pagamento,
	)

	if err != nil {
		log.Printf("Erro ao inserir forma de pagamento: %v", err)
	}
	return err
}

// ################################################# UPDATE forma de pagamento (sem transação)

func (d *FormaPagamentoDatastore) UpdateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	query := `update forma_pagamento set 
	sale_id=$1,
	forma_de_pagamento=$2,
	valor_pago=$3,
	data_pagamento=$4
where id_forma_pagamento=$5
RETURNING
    id_forma_pagamento,
    sale_id,
    forma_de_pagamento,
    valor_pago,
    data_pagamento`

	var t entity.FormaPagamento
	err := d.Conn.QueryRow(context.Background(), query,
		formaPagamento.Sale_id,
		formaPagamento.Forma_de_pagamento,
		formaPagamento.Valor_pago,
		formaPagamento.Data_pagamento,
		formaPagamento.Id_forma_pagamento).Scan(
		&t.Id_forma_pagamento,
		&t.Sale_id,
		&t.Forma_de_pagamento,
		&t.Valor_pago,
		&t.Data_pagamento,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("Forma de pagamento não encontrada para atualização: %v", err)

		}
		return nil, fmt.Errorf("Erro ao atualizar o metodo de pagamento")
	}

	return &t, nil
}

// ################################################# UPDATE forma de pagamento TX (dentro de uma transação)

func (d *FormaPagamentoDatastore) UpdateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	query := `update forma_pagamento set 
	sale_id=$1,
	forma_de_pagamento=$2,
	valor_pago=$3,
	data_pagamento=$4
where id_forma_pagamento=$5
RETURNING
    id_forma_pagamento,
    sale_id,
    forma_de_pagamento,
    valor_pago,
    data_pagamento`

	var t entity.FormaPagamento
	err := d.Conn.QueryRow(context.Background(), query,
		formaPagamento.Sale_id,
		formaPagamento.Forma_de_pagamento,
		formaPagamento.Valor_pago,
		formaPagamento.Data_pagamento,
		formaPagamento.Id_forma_pagamento).Scan(
		&t.Id_forma_pagamento,
		&t.Sale_id,
		&t.Forma_de_pagamento,
		&t.Valor_pago,
		&t.Data_pagamento,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("Forma de pagamento não encontrada para atualização: %v", err)

		}
		return nil, fmt.Errorf("Erro ao atualizar o metodo de pagamento")
	}

	return &t, nil

}

// ################################################# Read forma de pagamento pelo Id (sem transação)
func (d *FormaPagamentoDatastore) ReadFormaPagamentoById(ctx context.Context, id int) (*entity.FormaPagamento, error) {
	query := `select id_forma_pagamento, sale_id, forma_de_pagamento, valor_pago, data_pagamento 
	from forma_pagamento where id=$1`
	var t entity.FormaPagamento
	err := d.Conn.QueryRow(context.Background(), query, id).Scan(
		&t.Id_forma_pagamento,
		&t.Sale_id,
		&t.Forma_de_pagamento,
		&t.Valor_pago,
		&t.Data_pagamento,
	)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("Forma de pagamento não encontrada: %v", err)
		}
		return nil, fmt.Errorf("Erro ao ler o metodo de pagamento")
	}

	return &t, nil
}

// ################################################# Read Todos os registros de pagamento
func (d *FormaPagamentoDatastore) ReadAllFormaPagamento(ctx context.Context) ([]*entity.FormaPagamento, error) {
	query := `select id_forma_pagamento, sale_id, forma_de_pagamento, valor_pago, data_pagamento 
	from forma_pagamento where DATE(data_pagamento ) = current_date;`
	rows, err := d.Conn.Query(ctx, query)
	if err != nil {
		return nil, fmt.Errorf("Erro ao ler os metodos de pagamento: %v", err)
	}
	defer rows.Close()

	var formasPagamento []*entity.FormaPagamento
	for rows.Next() {
		var t entity.FormaPagamento
		err := rows.Scan(
			&t.Id_forma_pagamento,
			&t.Sale_id,
			&t.Forma_de_pagamento,
			&t.Valor_pago,
			&t.Data_pagamento,
		)
		if err != nil {
			return nil, fmt.Errorf("Erro ao escanear o metodo de pagamento: %v", err)
		}
		formasPagamento = append(formasPagamento, &t)
	}

	return formasPagamento, nil
}

// ################################################# Delete forma de pagamento pelo Id (sem transação)
func (d *FormaPagamentoDatastore) DeleteFormaPagamentoById(ctx context.Context, sale_id int) error {
	query := `delete from forma_pagamento where sale_id=$1`
	_, err := d.Conn.Exec(ctx, query, sale_id)
	if err != nil {
		log.Printf("Erro ao deletar forma de pagamento: %v", err)
		return err
	}
	return nil
}
