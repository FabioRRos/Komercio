package entity

import (
	"fmt"
	"time"
)

type FormaPagamento struct {
	Id_forma_pagamento int       `json:"id_forma_pagamento"`
	Sale_id            int       `json:"sale_id"`
	Forma_de_pagamento string    `json:"forma_de_pagamento"`
	Valor_pago         float32   `json:"valor_pago"`
	Data_pagamento     time.Time `json:"data_pagamento"`
}

func ValidarCamposFormaPagamento(formaPagamento *FormaPagamento) error {

	if formaPagamento.Forma_de_pagamento == "" {
		return fmt.Errorf("Forma de pagamento inválida!")
	}
	if formaPagamento.Valor_pago <= 0 {
		return fmt.Errorf("Valor pago inválido!")
	}

	return nil
}
