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
	case !ValidateDocumentNumber(customer.CustomerDocument):
		return fmt.Errorf("CPF ou CNPJ invalido")
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

func ValidateDocumentNumber(doc string) bool {

	numDigitos := len(doc)

	if numDigitos == 11 {

		soma := 0
		for i := 0; i < 9; i++ {
			soma += int(doc[i]-'0') * (10 - i)
		}

		resto := soma % 11
		digito1 := 0
		if resto >= 2 {
			digito1 = 11 - resto
		}

		soma = 0
		for i := 0; i < 10; i++ {
			soma += int(doc[i]-'0') * (11 - i)
		}

		resto = soma % 11
		digito2 := 0
		if resto >= 2 {
			digito2 = 11 - resto
		}

		return int(doc[9]-'0') == digito1 && int(doc[10]-'0') == digito2

	} else if numDigitos == 14 {
		// peso para os dois digitos
		peso1 := []int{5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}
		peso2 := []int{6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}

		// primeiro digito
		soma := 0
		for i := 0; i < 12; i++ {
			soma += int(doc[i]-'0') * peso1[i]
		}
		resto := soma % 11
		digito1 := 0
		if resto >= 2 {
			digito1 = 11 - resto
		}

		// Segundo digito
		soma = 0
		for i := 0; i < 13; i++ {
			soma += int(doc[i]-'0') * peso2[i]
		}
		resto = soma % 11
		digito2 := 0
		if resto >= 2 {
			digito2 = 11 - resto
		}

		return int(doc[12]-'0') == digito1 && int(doc[13]-'0') == digito2

	} else {
		return false
	}
}
