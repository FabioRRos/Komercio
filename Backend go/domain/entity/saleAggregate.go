package entity

// SaleAggregate é o cara onde vou salvar os dados da venda no json
type SaleAggregate struct {
	Sale         Sales         `json:"sale"`
	Items        []SalesItens  `json:"items"`
	CashMovement Cashmovements `json:"cash_movement"`
}
