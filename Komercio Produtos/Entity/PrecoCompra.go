package entity

import (
	"fmt"
	"time"
)

type PrecoCompra struct {
	IDPrecoCompra int
	CodigoBarras  string
	ValorCompra   float64
	Quantidade    int
	Status        bool
	DataEntrada   time.Time
	Obs           string
}

func ProductToPrecoCompra(produto *Product) (*PrecoCompra, error) {

	if produto.ProductCodBar == "" {
		return nil, fmt.Errorf("código de barras inválido")
	}

	if produto.ProductStock < 0 {
		return nil, fmt.Errorf("quantidade inválid - %s", produto.ProductCodBar)
	}

	if produto.ProductPrice < 0 {
		return nil, fmt.Errorf("preço do produto inválido - %s", produto.ProductCodBar)
	}

	produtoEntradaPreco := &PrecoCompra{
		CodigoBarras: produto.ProductCodBar,
		Quantidade:   produto.ProductStock,
		DataEntrada:  time.Now(),
		Obs:          produto.ProductName,
		Status:       true,
	}

	if produto.ProductStock <= 0 {

		produtoEntradaPreco.Status = false
	}

	if produto.ProductPrchasePrice > 0 {
		produtoEntradaPreco.ValorCompra = produto.ProductPrchasePrice
	} else {
		produtoEntradaPreco.ValorCompra = produto.ProductPrice
		produtoEntradaPreco.Obs += " (fallback preço venda)"
	}

	return produtoEntradaPreco, nil
}
