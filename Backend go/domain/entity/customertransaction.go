package entity

import (
	"fmt"
	"strconv"
	"time"
)

type CustomerTransaction struct {
	Id_transaction    int       `json:"id_transaction"`
	Sale_id           int       `json:"sale_id"`
	Customer_id       int       `json:"customer_id"`
	Origin_type       string    `json:"origin_type"`
	Transaction_value float32   `json:"transaction_value"`
	Transaction_date  time.Time `json:"transaction_date"`
	Obs               string    `json:"obs"`
	Seller            string    `json:"seller"`
	Type_payment      string    `json:"type_payment"`
}

func TransactionValidation(transaction *CustomerTransaction) error {

	// Sale_id deve existir
	if transaction.Sale_id < 0 {
		return fmt.Errorf("sale_id inválido")
	}

	// customer_id deve existir
	if transaction.Customer_id <= 0 {
		return fmt.Errorf("customer_id inválido")
	}

	// origin_type não pode ser vazio
	if transaction.Origin_type == "" {
		return fmt.Errorf("origin_type não pode ser vazio")
	}

	// valor da transação deve ser maior que zero
	if transaction.Transaction_value <= 0 {
		return fmt.Errorf("transaction_value inválido")
	}

	// seller id deve existir
	if transaction.Seller == "" {
		return fmt.Errorf("seller inválido")
	}
	if _, err := strconv.Atoi(transaction.Seller); err != nil {
		return fmt.Errorf("seller inválido")
	}

	// tipo de pagamento não pode ser vazio
	if transaction.Type_payment == "" {
		return fmt.Errorf("type_payment não pode ser vazio")
	}

	transaction.Transaction_date = time.Now() // Como só vou utilizar na entrada de pagamento, já vou atribuir aqui a data. Assim não preciso me preocupar com o front.

	return nil
}
