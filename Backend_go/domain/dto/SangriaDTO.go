package dto

import "time"

type SangriaDTO struct {
	TipoMovimentacao  string    `json:"TipoMovimentacao"`
	Descricao         string    `json:"Descricao"`
	ValorSangria      float64   `json:"ValorSangria"`
	MetodoDePagamento string    `json:"MetodoDePagamento"`
	Data              time.Time `json:"Data"`
}
