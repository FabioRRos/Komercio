package entity

type ProductNotification struct {
	Id_productNotification int    `json:"Id_productNotification"`
	Productname            string `json:"Productname"`
	Productstock           int    `json:"Productstock"`
	Notify_enabled         bool   `json:"Notify_enabled"`
}
