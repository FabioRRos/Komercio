package entity

import "time"

type Salereport struct {
	SaleId           int       `json:"saleid"`
	CustomerName     string    `json:"customername"`
	CustomerDocument string    `json: "customerdoccument"`
	SallerName       string    `json: "sallername"`
	TotalAmount      float32   `json: "totalamount"`
	DiscountAmount   float32   `json: "discountamount"`
	FinalAmout       float32   `json: "finalamout"`
	SaleDate         time.Time `json: "saledate"`
	SaleTime         string    `json: "saletime`
	PaymentMethod    string    `json: "paymentmethod"`
	SaleNotes        string    `json: "salenotes"`
}
