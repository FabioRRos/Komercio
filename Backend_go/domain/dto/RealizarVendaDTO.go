package dto

type RealizarVendaDto struct {
	ProdutoId  int    `json:"produto_id"`
	Quantidade int    `json:"quantidade"`
	IdVenda    string `json:"id_venda"`
}
