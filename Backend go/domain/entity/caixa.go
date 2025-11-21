package entity

import "time"

type Caixa struct {
	IDTransiction int       `json:"id_transiction"` // ID da transação
	ValueChanged  float32   `json:"value_changed"`  // valor da transação
	ChangeType    string    `json:"change_type"`    // entrada ou saída
	ChangeOrigin  string    `json:"change_origin"`  // venda, sangria, depósito, etc.
	ChangeDate    time.Time `json:"change_date"`    // ISO8601
	VendedorID    int       `json:"vendedor_id"`    // quem efetuou
	Status        bool      `json:"status"`         // aberto/fechado
	Observations  string    `json:"observations"`   // observações
}
