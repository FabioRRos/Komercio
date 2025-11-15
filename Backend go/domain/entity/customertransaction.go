package entity

import "time"

type CustomerTransaction struct {
	Id_transaction    int       `json:"id_transaction"`
	Sale_id           int       `json:"sale_id"`
	Customer_id       int       `json:"customer_id"`
	Origin_type       string    `json:"origin_type"`
	Transaction_value float32   `json:"transaction_value"`
	Transaction_date  time.Time `json:"transaction_date"`
	Obs               string    `json:"obs"`
	Seller            int       `json:"seller"`
	Type_payment      string    `json:"type_payment"`
}
