package dto

type RegistrarEntradaDto struct {
	CodigoBarras string  `json:"CodBar"`
	Quantidade   int     `json:"quantidade"`
	PrecoCusto   float32 `json:"preco_custo"`
	NumeroNota   string  `json:"numero_nota"`
}
