package entity

type Product struct {
	Id                  int     `json:"id"`
	ProductName         string  `json:"product_name"`
	ProductPrice        float64 `json:"product_price"`
	ProductCodBar       string  `json:"product_codbar"`
	ProductGroup        string  `json:"product_group"`
	ProductSubGroup     string  `json:"product_subgroup"`
	ProductStock        int     `json:"product_stock"`
	ProductStatus       bool    `json:"product_status"`
	ProductPrchasePrice float64 `json:"product_purchase_price"`
}
