package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type EmployeeService interface {
	CreateEmployee(ctx context.Context, employee *entity.Employees) error
	ValidateLogin(ctx context.Context, login, password string) (bool, error)
	GetActiveEmployeeNames(ctx context.Context) ([]string, error)
	UpdateEmployeePassword(ctx context.Context, login, newPassword string) error
	UpdateEmployeeName(ctx context.Context, login, newName string) error
	DeactivateEmployee(ctx context.Context, login string) error
}

type employeeService struct {
	repo repository.EmployeesRepository
}

func NewEmployeeService(repo repository.EmployeesRepository) EmployeeService {
	return &employeeService{repo: repo}
}

func (s *employeeService) CreateEmployee(ctx context.Context, employee *entity.Employees) error {
	if employee == nil {
		return errors.New("funcionário não pode ser nulo")
	}

	if err := entity.ValidatePassword(employee); err != nil {
		return err
	}

	if err := entity.CreateLogin(employee); err != nil {
		return err
	}

	return s.repo.Create(ctx, employee)
}

func (s *employeeService) ValidateLogin(ctx context.Context, login, password string) (bool, error) {
	if login == "" || password == "" {
		return false, nil // login ou senha vazios não são válidos
	}
	return s.repo.ValidateLogin(ctx, login, password)
}

func (s *employeeService) GetActiveEmployeeNames(ctx context.Context) ([]string, error) {
	return s.repo.SelectActiveEmployeeNames(ctx)
}

func (s *employeeService) UpdateEmployeePassword(ctx context.Context, login, newPassword string) error {
	if login == "" || newPassword == "" {
		return errors.New("login ou senha inválidos")
	}

	if err := entity.ChangePassword(newPassword); err != nil {
		return err
	}

	return s.repo.UpdateEmployeePassword(ctx, login, newPassword)
}

func (s *employeeService) UpdateEmployeeName(ctx context.Context, login, newName string) error {
	if login == "" || newName == "" {
		return errors.New("login ou nome inválidos")
	}

	return s.repo.UpdateEmployeeName(ctx, login, newName)
}

func (s *employeeService) DeactivateEmployee(ctx context.Context, login string) error {
	if login == "" {
		return errors.New("login inválido")
	}

	return s.repo.DeactivateEmployee(ctx, login)
}
