package dto

import "time"

type ValorCompra struct {
	ValorCompra float32 `json:"valor_compra"`
}

type Produto struct {
	ProductID   int           `json:"product_id"`
	ProductName string        `json:"product_name"`
	UnitPrice   float32       `json:"unit_price"`
	Quantity    int           `json:"quantity"`
	Total       float32       `json:"total"`
	Costs       []ValorCompra `json:"costs"`
}

type JsonVenda struct {
	SaleID      int       `json:"sale_id"`
	TotalAmount float32   `json:"total_amount"`
	SaleDate    time.Time `json:"sale_date"`
	Payment     string    `json:"payment"`
	SellerName  string    `json:"sellerName"`
	Products    []Produto `json:"products"`
}
