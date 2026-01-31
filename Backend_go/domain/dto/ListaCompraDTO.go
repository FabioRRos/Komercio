package dto

import "time"

type ListaComprasDTO struct {
	IdListaCompra    int32     `json:"idListaCompra"`
	NomeDaLista      string    `json:"nomeDaLista"`
	DataCriacaoLista time.Time `json:"dataCriacaoLista"`
	StatusLista      bool      `json:"statusLista"`
}
