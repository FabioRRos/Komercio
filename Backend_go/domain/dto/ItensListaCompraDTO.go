package dto

import "fmt"

type ItensListaCompraDTO struct {
	IdItemCompra     int    `json:"IdItemCompra"`
	IdLista          int    `json:"IdLista"`
	DescricaoProduto string `json:"DescricaoProduto"`
	CodBar           string `json:"CodBar"`
	Quantidade       int    `jon:"Quantidade"`
	StatusItem       bool   `json:"StatusItem"`
	Obs              string `json:"Obs"`
}

func ValidaItemListaCompras(item *ItensListaCompraDTO) error {

	if item.IdLista <= 0 {
		return fmt.Errorf("Id da lista invalido!")
	}
	if item.DescricaoProduto == "" {
		return fmt.Errorf("Descrição do protudo invalido")
	}
	if item.CodBar == "" {
		return fmt.Errorf("Código de barras invalido")
	}
	if item.Quantidade <= 0 {
		return fmt.Errorf("Quantidade invalida!")
	}

	return nil

}
