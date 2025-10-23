package entity

import "time"

type Sales struct {
	SalesId        int       `json:"sale_id"`
	CustomerId     int       `json:"customer_id"`
	TotalAmount    float32   `json:"total_amount"`
	DiscountAmount float32   `json:"discount_amount"`
	FinalAmount    float32   `json:"final_amount"`
	SalesDate      time.Time `json:"sale_date"`
	SalesHour      string    `json:"sale_time"`
	PaymentMethod  string    `json:"payment_method"`
	SellerId       int       `json:"saller_id"`
	SaleNotes      string    `json:"sale_note"`
}
