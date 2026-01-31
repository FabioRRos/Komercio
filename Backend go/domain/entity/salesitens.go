package entity

import (
	"fmt"
)

type SalesItens struct {
	SaleItemId  int     `json:"sale_item_id"`
	SaleId      int     `json:"sale_id"`
	ProductId   int     `json:"product_id"`
	ProductName string  `json:"product_name"`
	Barcode     string  `json:"barcode"`
	UnitPrice   float32 `json:"unit_price"`
	Quantity    int     `json:"quantity"`
	Total       float32 `json:"total"`
}

func ValidateSaleItem(item *SalesItens) (*SalesItens, error) {
	if item == nil {
		return nil, fmt.Errorf("item não pode ser nulo")
	}
	if item.SaleId == 0 {
		return nil, fmt.Errorf("Id da venda é obrigatório")
	}
	if item.Barcode == "" {
		return nil, fmt.Errorf("Código de barras é obrigatório")
	}
	if item.ProductId == 0 {
		return nil, fmt.Errorf("Id do produto é obrigatório")
	}
	if item.Quantity <= 0 {
		return nil, fmt.Errorf("Quantidade deve ser maior que zero")
	}
	if item.UnitPrice <= 0 {
		return nil, fmt.Errorf("Preço unitário inválido")
	}
	if item.Total == 0 {
		item.Total = item.UnitPrice * float32(item.Quantity)
	}
	return item, nil
}
