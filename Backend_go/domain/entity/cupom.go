package entity

type CupomDTO struct {
	Salereport Salereport    `json:"salereport"`
	SaleItens  []*SalesItens `json:"saleitens"`
}
