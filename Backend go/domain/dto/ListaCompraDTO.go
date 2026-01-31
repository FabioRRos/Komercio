package dto

import "github.com/fabioros/Komercio/internal/shared"

type ListaComprasDTO struct {
	IdListaCompra    int32              `Json:"idListaCompra"`
	NomeDaLista      string             `Json:"nomeDaLista"`
	DataCriacaoLista shared.ISO8601Time `Json:"dataCriacaoLista"`
	StatusLista      bool               `Json:"statusLista"`
}
