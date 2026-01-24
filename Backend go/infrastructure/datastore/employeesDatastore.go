package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

type EmployeesDatastore struct {
	Pool *pgxpool.Pool
}

func NewEmployeesDataStore(pool *pgxpool.Pool) *EmployeesDatastore {
	return &EmployeesDatastore{
		Pool: pool,
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

	_, err := d.Pool.Exec(
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
	err := d.Pool.QueryRow(context.Background(), query, login, password).Scan(&exists)
	if err != nil {
		if err == pgx.ErrNoRows {
			return false, nil
		}
		return false, fmt.Errorf("erro ao validar login: %w", err)
	}
	return true, nil
}
func (d *EmployeesDatastore) SelectActiveEmployeeNames() ([]int, []string, error) {
	query := `
		SELECT EmployeeID, EmployeeFullName
		FROM employees
		WHERE EmployeeStatus = true
	`
	rows, err := d.Pool.Query(context.Background(), query)
	if err != nil {
		return nil, nil, fmt.Errorf("erro ao consultar funcionários ativos: %w", err)
	}

	var ids []int
	var names []string

	for rows.Next() {
		var id int
		var name string
		if err := rows.Scan(&id, &name); err != nil {
			return nil, nil, fmt.Errorf("erro ao ler funcionário: %w", err)
		}
		ids = append(ids, id)
		names = append(names, name)
	}

	return ids, names, nil
}

func (d *EmployeesDatastore) UpdateEmployeePassword(login, newPassword string) error {
	query := `
		UPDATE employees
		SET EmployeePassword = $2
		WHERE EmployeeLogin = $1
	`
	_, err := d.Pool.Exec(context.Background(), query, login, newPassword)
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
	_, err := d.Pool.Exec(context.Background(), query, login, newName)
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
	_, err := d.Pool.Exec(context.Background(), query, login)
	if err != nil {
		return fmt.Errorf("erro ao desativar funcionário: %w", err)
	}
	return nil
}

func (d *EmployeesDatastore) ValidateLoginAdmin(login, password string) (bool, error) {
	query := `
        SELECT 1
        FROM employees
        WHERE employeelogin = $1
        AND employeepassword = $2
		AND employeeadmin = true
        LIMIT 1
    `
	var exists int
	err := d.Pool.QueryRow(context.Background(), query, login, password).Scan(&exists)
	if err != nil {
		if err == pgx.ErrNoRows {
			return false, nil
		}
		return false, fmt.Errorf("Acesso negado: %w", err)
	}
	return true, nil
}
