package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type CustomerRepository interface {
	Create(ctx context.Context, customer *entity.Customer) error
	SelectAllCustomers(ctx context.Context) ([]*entity.Customer, error)
	SelectCustomerById(ctx context.Context, id int) (*entity.Customer, error)
	UpdateCustomer(ctx context.Context, customer *entity.Customer) (*entity.Customer, error)
	DeactivateCustomer(ctx context.Context, id int) error
}

type customerRepository struct {
	datastore *datastore.CustomerDatastore
}

func NewCustomerRepository(ds *datastore.CustomerDatastore) CustomerRepository {
	return &customerRepository{
		datastore: ds,
	}
}

func (r *customerRepository) Create(ctx context.Context, customer *entity.Customer) error {
	return r.datastore.CreateCustomer(customer)
}

func (r *customerRepository) SelectAllCustomers(ctx context.Context) ([]*entity.Customer, error) {
	return r.datastore.SelectAllCustomers()
}

func (r *customerRepository) SelectCustomerById(ctx context.Context, id int) (*entity.Customer, error) {
	return r.datastore.SelectCustomerById(id)
}

func (r *customerRepository) UpdateCustomer(ctx context.Context, customer *entity.Customer) (*entity.Customer, error) {
	return r.datastore.UpdateCustomer(customer)
}

func (r *customerRepository) DeactivateCustomer(ctx context.Context, id int) error {
	return r.datastore.DeactivateCustomer(id)
}
