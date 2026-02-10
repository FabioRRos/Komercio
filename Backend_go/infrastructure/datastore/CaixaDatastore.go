package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type CaixaDatastore struct {
	Pool *pgxpool.Pool
}

func NewCaixaDatastore(pool *pgxpool.Pool) *CaixaDatastore {

	return &CaixaDatastore{Pool: pool}
}

// creat (PUT) TX porque ele está no fluxo de pagamento.
func (d *CaixaDatastore) CaixaChangeTX(ctx context.Context, tx pgx.Tx, caixa *entity.Caixa) error {
	query := `INSERT INTO caixa (
    value_changed,
    change_type,
    change_origin,
    change_date,
    usuario_id,
    status,
    observations
) VALUES (
    $1,   -- Valor da transação
    $2,   -- Entrada, saida
    $3,   -- venda, sangria, depósito, fechamento etc.
    $4,   -- data da mudança 
    $5,   -- Id do vendedor
    $6,   -- Status do caixa (aberto/fechado)
    $7    -- observações (Caixa com alteração, id da venda etc.)
)`
	_, err := tx.Exec(ctx, query,
		caixa.ValueChanged,
		caixa.ChangeType,
		caixa.ChangeOrigin,
		caixa.ChangeDate,
		caixa.VendedorID,
		caixa.Status,
		caixa.Observations,
	)
	if err != nil {
		return fmt.Errorf("Não consegui seguir %w", err)
	}

	return nil
}

// PUT SEM TX porque pode ser movimentação por outros motivos fora do fluxo de venda.
func (d *CaixaDatastore) CaixaChange(ctx context.Context, caixa *entity.Caixa) error {
	query := `INSERT INTO caixa (
    value_changed,
    change_type,
    change_origin,
    change_date,
    usuario_id,
    status,
    observations
) VALUES (
    $1,   -- Valor da transação
    $2,   -- Entrada, saida
    $3,   -- venda, sangria, depósito, fechamento etc.
    $4,   -- data da mudança 
    $5,   -- Id do vendedor
    $6,   -- Status do caixa (aberto/fechado)
    $7    -- observações (Caixa com alteração, id da venda etc.)
)`
	_, err := d.Pool.Exec(ctx, query,
		caixa.ValueChanged,
		caixa.ChangeType,
		caixa.ChangeOrigin,
		caixa.ChangeDate,
		caixa.VendedorID,
		caixa.Status,
		caixa.Observations,
	)
	if err != nil {
		return err
	}

	return nil
}

// GET geral
func (d *CaixaDatastore) GetCaixa(ctx context.Context) ([]*entity.Caixa, error) {
	query := `select * from caixa c where DATE(change_date ) = current_date`
	row, err := d.Pool.Query(ctx, query)

	if err != nil {
		return nil, fmt.Errorf("Erro ao buscar as alterações no caixa: %w", err)
	}

	var caixaReturn []*entity.Caixa
	for row.Next() {
		var caixa entity.Caixa

		err = row.Scan(
			&caixa.IDTransiction,
			&caixa.ValueChanged,
			&caixa.ChangeType,
			&caixa.ChangeOrigin,
			&caixa.ChangeDate,
			&caixa.VendedorID,
			&caixa.Status,
			&caixa.Observations,
		)
		if err != nil {
			return nil, err
		}
		caixaReturn = append(caixaReturn, &caixa)

	}
	return caixaReturn, nil
}

func (d *CaixaDatastore) StatusCaixa(ctx context.Context) (*bool, error) {
	query := `SELECT (change_origin = 'Abertura') as is_abertura
FROM caixa
WHERE change_origin IN ('Abertura', 'Fechamento')
ORDER BY id_transiction DESC
LIMIT 1;`
	var status *bool

	row, err := d.Pool.Query(ctx, query)

	if err != nil {
		return status, fmt.Errorf("Não consegui trazer o status do caixa.")
	}

	for row.Next() {
		err = row.Scan(
			&status,
		)
		if err != nil {
			return status, err
		}
	}
	return status, nil
}
