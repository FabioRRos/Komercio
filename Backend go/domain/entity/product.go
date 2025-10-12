package entity

import "fmt"

type Product struct {
	Id              int
	ProductName     string
	ProductPrice    float32
	ProductCodBar   string
	ProductGroup    string
	ProductSubGroup string
	ProductStock    int
}

func ProductValidation(product Product) error {

	if product.ProductPrice <= 0 {
		return fmt.Errorf("O preço não pode ser negativo ou zero")
	}
	if product.ProductCodBar == "" {
		return fmt.Errorf("Código de barras é obrigatório")
	}
	if product.ProductStock < 0 {
		return fmt.Errorf("Estoque não pode ser negativo")
	}
	return nil
}
