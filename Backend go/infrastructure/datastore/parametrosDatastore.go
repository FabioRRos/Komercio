package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type ParametrosDatastore struct {
	Pool *pgxpool.Pool
}

func NewParametrosDatastore(Pool *pgxpool.Pool) *ParametrosDatastore {

	return &ParametrosDatastore{Pool: Pool}

}

func (d *ParametrosDatastore) GetParametros() ([]*entity.Parametros, error) {
	query := "SELECT * FROM parametros order by id_parametro  asc;"

	rows, err := d.Pool.Query(context.Background(), query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar parâmetros: %w", err)
	}

	var parametros []*entity.Parametros

	for rows.Next() {
		var p entity.Parametros
		err := rows.Scan(
			&p.Parametro_Id,
			&p.Parametro_name,
			&p.Parametro_status,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do produto: %w", err)
		}
		parametros = append(parametros, &p)
	}
	return parametros, nil
}

func (d *ParametrosDatastore) PostParametros(ParametroLista *entity.Parametros) (*entity.Parametros, error) {
	query := `UPDATE parametros
	SET status_parametro = $2
	WHERE id_parametro = $1
	RETURNING id_parametro, parametro , status_parametro`

	var p entity.Parametros

	err := d.Pool.QueryRow(context.Background(), query,
		ParametroLista.Parametro_Id,
		ParametroLista.Parametro_status,
	).Scan(
		&p.Parametro_Id,
		&p.Parametro_name,
		&p.Parametro_status,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("parametro com o id %d não encontrado", ParametroLista.Parametro_Id)
		}
		return nil, fmt.Errorf("Erro ao atualizar o parametro: %w", err)
	}

	return &p, nil

}
