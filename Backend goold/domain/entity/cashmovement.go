package entity

import (
	"time"
)

type Cashmovements struct {
	Cashmovementsid            int       `json:"movement_id"`
	SalesId                    int       `json:"sale_id"`
	Cashmovementstype          string    `json:"movement_type"`
	Cashmovementsdescription   string    `json:"description"`
	Cashmovementsamount        float32   `json:"amount"`
	Cashmovementspaymentmethod string    `json:"payment_method"`
	Cashmovementsdatetime      time.Time `json:"movement_datetime"`
	SellerId                   int       `json:"seller_id"`
}
