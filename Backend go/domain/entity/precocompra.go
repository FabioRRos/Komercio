package entity

import (
	"fmt"
	"time"
)

type PrecoCompra struct {
	IDPrecoCompra int       `json:"id_preco_compra"`
	CodigoBarras  string    `json:"codigobarras"`
	ValorCompra   float32   `json:"valorcompra"`
	Quantidade    int       `json:"quantidade"`
	Status        bool      `json:"status"`
	DataEntrada   time.Time `json:"dataentrada"`
	Obs           string    `json:"obs"`
}

func ProductToPrecocompra(produto *Product) (*PrecoCompra, error) {

	if produto.ProductCodBar == "" {
		return nil, fmt.Errorf("Código de barras inválido")
	}

	if produto.ProductStock <= 0 {
		return nil, fmt.Errorf("Quantidade inválida")
	}

	// adicionar o if do preço do produto.

	produtoEntradaPreco := &PrecoCompra{
		CodigoBarras: produto.ProductCodBar,
		Quantidade:   produto.ProductStock,
		Status:       true,
		DataEntrada:  time.Now(),
		Obs:          produto.ProductName,
	}
	//se o valor ficar como zero, durante o calculo vou ter todo o valor do produto como margem de lucro.
	if produto.ProductPrchasePrice == 0 {
		produtoEntradaPreco.ValorCompra = produto.ProductPrice
	} else {
		produtoEntradaPreco.ValorCompra = produto.ProductPrchasePrice
	}

	return produtoEntradaPreco, nil
}
