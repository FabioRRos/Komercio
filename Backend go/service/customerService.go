package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type CustomerService interface {
	CreateCustomer(ctx context.Context, customer *entity.Customer) error
	SelectAllCustomers(ctx context.Context) ([]*entity.Customer, error)
	SelectCustomerById(ctx context.Context, id int) (*entity.Customer, error)
	UpdateCustomer(ctx context.Context, customer *entity.Customer) (*entity.Customer, error)
	DeactivateCustomer(ctx context.Context, id int) error
}

type customerService struct {
	repo repository.CustomerRepository
}

func NewCustomerService(repo repository.CustomerRepository) CustomerService {
	return &customerService{repo: repo}
}

func (s *customerService) CreateCustomer(ctx context.Context, customer *entity.Customer) error {
	if customer == nil {
		return errors.New("Cliente não pode ser nulo")
	}

	err := entity.CustomerValidation(customer)

	if err != nil {
		return err
	}

	return s.repo.Create(ctx, customer)
}

func (s *customerService) SelectAllCustomers(ctx context.Context) ([]*entity.Customer, error) {
	customers, err := s.repo.SelectAllCustomers(ctx)
	if err != nil {
		return nil, err
	}

	// Filtra apenas clientes ativos
	var activeCustomers []*entity.Customer
	for _, c := range customers {
		if c.CustomerStatus {
			activeCustomers = append(activeCustomers, c)
		}
	}

	return activeCustomers, nil
}

func (s *customerService) SelectCustomerById(ctx context.Context, id int) (*entity.Customer, error) {
	if id <= 0 {
		return nil, errors.New("id inválido")
	}

	customer, err := s.repo.SelectCustomerById(ctx, id)
	if err != nil {
		return nil, err
	}

	return customer, nil
}

func (s *customerService) UpdateCustomer(ctx context.Context, customer *entity.Customer) (*entity.Customer, error) {
	if customer == nil || customer.CustomerID <= 0 {
		return nil, errors.New("cliente inválido para atualização")
	}

	if err := entity.CustomerValidation(customer); err != nil {
		return nil, errors.New("parâmetros inválidos")
	}

	updated, err := s.repo.UpdateCustomer(ctx, customer)
	if err != nil {
		return nil, err
	}

	return updated, nil
}

func (s *customerService) DeactivateCustomer(ctx context.Context, id int) error {
	if id <= 0 {
		return errors.New("id inválido")
	}
	return s.repo.DeactivateCustomer(ctx, id)
}
