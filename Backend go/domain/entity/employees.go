package entity

import (
	"fmt"
	"strings"
	"unicode"
)

type Employees struct {
	EmployeeID       int    `Json:"employees_id"`
	EmployeeFullName string `Json:"employees_name"`
	EmployeeLogin    string `Json:"employees_login"`
	EmployeePassword string `Json:"employees_password"`
}

func CreateLogin(employee *Employees) error {

	palavras := strings.Fields(employee.EmployeeFullName)

	if len(palavras) <= 1 {
		return fmt.Errorf("O nome não pode estar em branco")

	}

	firstInitial := unicode.ToLower(rune(palavras[0][0]))
	lastName := strings.ToLower(palavras[len(palavras)-1])
	employee.EmployeeLogin = string(firstInitial) + "." + lastName

	return nil
}

func ValidatePassword(password string) error {

	if len(password) < 4 {
		return fmt.Errorf("A senha precisa ter no minimo 8 caracteres")
	}

	return nil
}
