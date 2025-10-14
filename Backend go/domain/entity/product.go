package entity

import "fmt"

type Product struct {
	Id              int     `json:"id"`
	ProductName     string  `json:"product_name"`
	ProductPrice    float32 `json:"product_price"`
	ProductCodBar   string  `json:"product_codbar"`
	ProductGroup    string  `json:"product_group"`
	ProductSubGroup string  `json:"product_subgroup"`
	ProductStock    int     `json:"product_stock"`
	ProductStatus   bool    `json:"product_status"`
}

// Validação simples para uso antes de salvar
func ProductValidation(product Product) error {
	if product.ProductPrice <= 0 ||
		product.ProductCodBar == "" ||
		product.ProductStock < 0 {
		return fmt.Errorf("parâmetros inválidos para o produto")
	}
	return nil
}
