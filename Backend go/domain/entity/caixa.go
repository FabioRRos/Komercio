package entity

import (
	"fmt"
	"time"
)

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

func ValidaCampos(caixa *Caixa) error {

	if caixa.ValueChanged < 0 {
		return fmt.Errorf("Valor da transação invalido!")
	}
	if caixa.ChangeType == "" {
		return fmt.Errorf("Tipo de transação invalida!")
	}
	if caixa.ChangeOrigin == "" {
		return fmt.Errorf("Origem da transação invalida!")
	}

	if caixa.VendedorID < 0 {
		return fmt.Errorf("Necessário informar o vendedor!")
	}

	if caixa.Status != true && caixa.Status != false {
		return fmt.Errorf("Necessário informar o status da transação!")
	}
	caixa.ChangeDate = time.Now()

	return nil
}
