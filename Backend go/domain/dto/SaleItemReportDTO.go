package DTO

import "time"

type SaleItemReportDTO struct {
	// Identificação da venda
	SaleID   int       `json:"sale_id"`
	SaleDate time.Time `json:"sale_date"`
	SaleTime string    `json:"sale_time"`

	// Cliente / Vendedor
	CustomerID  int    `json:"customer_id"`
	SellerID    int    `json:"seller_id"`
	SellerName  string `json:"seller_name"`
	SellerLogin string `json:"seller_login"`

	// Produto
	SaleItemID  int    `json:"sale_item_id"`
	ProductID   int    `json:"product_id"`
	ProductName string `json:"product_name"`
	Barcode     string `json:"barcode"`

	// Valores de venda
	UnitPrice        float64 `json:"unit_price"`
	Quantity         int     `json:"quantity"`
	TotalSaleProduct float64 `json:"total_sale_product"`

	// Valores de compra (FIFO / CMV)
	TotalPurchaseProduct float64 `json:"total_purchase_product"`

	// Margem
	Margin float64 `json:"margin"`

	// Totais da venda
	TotalAmount    float64 `json:"total_amount"`
	DiscountAmount float64 `json:"discount_amount"`
	FinalAmount    float64 `json:"final_amount"`

	// Forma de pagamento
	PaymentMethod string `json:"payment_method"`
}
