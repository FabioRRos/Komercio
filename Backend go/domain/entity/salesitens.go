package entity

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
