package entity

import (
	"fmt"
	"strings"
	"unicode"
)

type Customer struct {
	CustomerID           int    `json:"customer_id"`           // ID do cliente
	CustomerFirstName    string `json:"customer_first_name"`   // Nome
	CustomerLastName     string `json:"customer_last_name"`    // Sobrenome / Razão Social
	CustomerDocument     string `json:"customer_document"`     // CPF/CNPJ
	CustomerPhone        string `json:"customer_phone"`        // Telefone
	CustomerMobile       string `json:"customer_mobile"`       // Celular
	CustomerAddressLine  string `json:"customer_address_line"` // Rua + número + complemento
	CustomerZipCode      string `json:"customer_zip_code"`     // CEP
	CustomerNeighborhood string `json:"customer_neighborhood"` // Bairro
	CustomerCity         string `json:"customer_city"`         // Cidade
	CustomerState        string `json:"customer_state"`        // Estado
	CustomerCountry      string `json:"customer_country"`      // País
	CustomerEmail        string `json:"customer_email"`        // Email
	CustomerAccountID    int    `json:"customer_account_id"`   // ID da conta (Para quando eu criar a caderneta)
	CustomerStatus       bool   `json:"customer_status"`       // Status (ativo = true, bloqueado = false)
}

func CustomerValidation(customer *Customer) error {

	switch {
	case customer.CustomerFirstName == "":
		return fmt.Errorf("O nome não pode estar em branco")
	case customer.CustomerLastName == "":
		return fmt.Errorf("O sobrenome não pode estar em branco")
	case customer.CustomerDocument == "":
		return fmt.Errorf("O CPF/CNPJ não pode estar em branco")
	default:
		{
			var sb strings.Builder
			for _, r := range customer.CustomerDocument {

				if unicode.IsDigit(r) {
					sb.WriteRune(r)
				}
			}
			customer.CustomerDocument = sb.String()

			return nil
		}
	}
}
