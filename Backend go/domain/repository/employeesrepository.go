package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type EmployeesRepository interface {
	Create(ctx context.Context, employees *entity.Employees) error
	ValidateLogin(ctx context.Context, login, password string) (bool, error)
	SelectActiveEmployeeNames(ctx context.Context) ([]int, []string, error)
	UpdateEmployeePassword(ctx context.Context, login, newPassword string) error
	UpdateEmployeeName(ctx context.Context, login, newName string) error
	DeactivateEmployee(ctx context.Context, login string) error

	ValidateLoginAdmin(ctx context.Context, login, password string) (bool, error)
}

type employeesRepository struct {
	datastore *datastore.EmployeesDatastore
}

func NewEmployeesRepository(ds *datastore.EmployeesDatastore) EmployeesRepository {
	return &employeesRepository{
		datastore: ds,
	}
}

func (r *employeesRepository) Create(ctx context.Context, employeer *entity.Employees) error {
	return r.datastore.CreateEmployees(employeer)
}

func (r *employeesRepository) ValidateLogin(ctx context.Context, login, password string) (bool, error) {
	return r.datastore.ValidateLogin(login, password)
}

func (r *employeesRepository) SelectActiveEmployeeNames(ctx context.Context) ([]int, []string, error) {
	return r.datastore.SelectActiveEmployeeNames()
}

func (r *employeesRepository) UpdateEmployeePassword(ctx context.Context, login, newPassword string) error {
	return r.datastore.UpdateEmployeePassword(login, newPassword)
}

func (r *employeesRepository) UpdateEmployeeName(ctx context.Context, login, newName string) error {
	return r.datastore.UpdateEmployeeName(login, newName)
}

func (r *employeesRepository) DeactivateEmployee(ctx context.Context, login string) error {
	return r.datastore.DeactivateEmployee(login)
}

func (r *employeesRepository) ValidateLoginAdmin(ctx context.Context, login, password string) (bool, error) {
	return r.datastore.ValidateLoginAdmin(login, password)
}
