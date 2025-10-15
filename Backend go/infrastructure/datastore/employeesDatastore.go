package datastore

import (
	"context"
	"fmt"
	"log"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
)

type EmployeesDatastore struct {
	Conn *pgx.Conn
}

func NewEmployeesDataStore() *EmployeesDatastore {
	connStr := "postgres://komercio:komercio@localhost:5432/komercio?sslmode=disable"

	conn, err := pgx.Connect(context.Background(), connStr)
	if err != nil {
		log.Fatalf("Erro ao conectar ao banco: %v", err)
	}
	return &EmployeesDatastore{Conn: conn}
}

func (d *EmployeesDatastore) Close() {
	if d.Conn != nil {
		d.Conn.Close(context.TODO())
	}
}

func (d *EmployeesDatastore) CreateEmployees(employees *entity.Employees) error {
	query := `
		INSERT INTO employees (
			EmployeeFullName,
			EmployeeLogin,
			EmployeePassword
		) VALUES ($1, $2, $3)
	`

	_, err := d.Conn.Exec(
		context.Background(),
		query,
		employees.EmployeeFullName,
		employees.EmployeeLogin,
		employees.EmployeePassword,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir o funcionário: %w", err)
	}

	return nil
}

func (d *EmployeesDatastore) ValidateLogin(login, password string) (bool, error) {
	query := `
        SELECT 1
        FROM employees
        WHERE employeelogin = $1
          AND employeepassword = $2
        LIMIT 1
    `
	var exists int
	err := d.Conn.QueryRow(context.Background(), query, login, password).Scan(&exists)
	if err != nil {
		if err == pgx.ErrNoRows {
			return false, nil
		}
		return false, fmt.Errorf("erro ao validar login: %w", err)
	}
	return true, nil
}

func (d *EmployeesDatastore) SelectActiveEmployeeNames() ([]string, error) {
	query := `
		SELECT EmployeeFullName
		FROM employees
		WHERE EmployeeStatus = true
	`
	rows, err := d.Conn.Query(context.Background(), query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar funcionários ativos: %w", err)
	}
	defer rows.Close()

	var names []string
	for rows.Next() {
		var name string
		if err := rows.Scan(&name); err != nil {
			return nil, fmt.Errorf("erro ao ler linha do funcionário: %w", err)
		}
		names = append(names, name)
	}

	return names, nil
}

func (d *EmployeesDatastore) UpdateEmployeePassword(login, newPassword string) error {
	query := `
		UPDATE employees
		SET EmployeePassword = $2
		WHERE EmployeeLogin = $1
	`
	_, err := d.Conn.Exec(context.Background(), query, login, newPassword)
	if err != nil {
		return fmt.Errorf("erro ao atualizar senha do funcionário: %w", err)
	}
	return nil
}

func (d *EmployeesDatastore) UpdateEmployeeName(login, newName string) error {
	query := `
		UPDATE employees
		SET EmployeeFullName = $2
		WHERE EmployeeLogin = $1
	`
	_, err := d.Conn.Exec(context.Background(), query, login, newName)
	if err != nil {
		return fmt.Errorf("erro ao atualizar nome do funcionário: %w", err)
	}
	return nil
}

func (d *EmployeesDatastore) DeactivateEmployee(login string) error {
	query := `
		UPDATE employees
		SET EmployeeStatus = false
		WHERE employeelogin = $1
	`
	_, err := d.Conn.Exec(context.Background(), query, login)
	if err != nil {
		return fmt.Errorf("erro ao desativar funcionário: %w", err)
	}
	return nil
}
