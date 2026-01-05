package entity

import (
	"fmt"
	"math/rand"
	"strconv"
	"time"
)

type Product struct {
	Id                  int     `json:"id"`
	ProductName         string  `json:"product_name"`
	ProductPrice        float32 `json:"product_price"`
	ProductCodBar       string  `json:"product_codbar"`
	ProductGroup        string  `json:"product_group"`
	ProductSubGroup     string  `json:"product_subgroup"`
	ProductStock        int     `json:"product_stock"`
	ProductStatus       bool    `json:"product_status"`
	ProductPrchasePrice float32 `json:"product_purchase_price"`
}

// Validação simples para uso antes de salvar
func ProductValidation(product Product) error {
	if product.ProductPrice < 0 ||
		product.ProductStock < 0 {
		return fmt.Errorf("parâmetros inválidos para o produto")
	}

	return nil
}

// Aqui também eu preciso criar um codigo de barras. Preciso pensar como fazer um caso o produto não tenhoa código de barras

func CreateCodbar() string {

	//Esse cara gera um numero aleatório
	rand.Seed(time.Now().UnixNano())

	num := rand.Intn(900000000) + 100000000

	return strconv.Itoa(num)
}
