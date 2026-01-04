package datastore

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5"
	"github.com/jackc/pgx/v5/pgxpool"
)

// Esse cara fará gerenciamento das conexões e as operações relacionadas aos produtos

type CustomerDatastore struct {
	Pool *pgxpool.Pool
}

//Será o cara repsonsavel por criar uma nova instância de productDataStore e conectar ao banco

func NewCustomerDataStore(pool *pgxpool.Pool) *CustomerDatastore {

	return &CustomerDatastore{
		Pool: pool,
	}
}

//Cadastra um novo cliente no banco de dados.

func (d *CustomerDatastore) CreateCustomer(customer *entity.Customer) error {
	query := `
		INSERT INTO Customers (
			CustomerFirstName,
			CustomerLastName,
			CustomerDocument,
			CustomerPhone,
			CustomerMobile,
			CustomerAddressLine,
			CustomerZipCode,
			CustomerNeighborhood,
			CustomerCity,
			CustomerState,
			CustomerCountry,
			CustomerEmail,
			CustomerAccountID,
			CustomerStatus
		) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10, $11, $12, $13, $14)
	`

	_, err := d.Pool.Exec(
		context.Background(),
		query,
		customer.CustomerFirstName,
		customer.CustomerLastName,
		customer.CustomerDocument,
		customer.CustomerPhone,
		customer.CustomerMobile,
		customer.CustomerAddressLine,
		customer.CustomerZipCode,
		customer.CustomerNeighborhood,
		customer.CustomerCity,
		customer.CustomerState,
		customer.CustomerCountry,
		customer.CustomerEmail,
		customer.CustomerAccountID,
		customer.CustomerStatus,
	)

	if err != nil {
		return fmt.Errorf("erro ao inserir cliente: %w", err)
	}

	return nil
}

func (d *CustomerDatastore) SelectAllCustomers() ([]*entity.Customer, error) {
	query := `
		SELECT * FROM Customers
	`

	rows, err := d.Pool.Query(context.Background(), query)
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar todos os clientes: %w", err)
	}

	var customers []*entity.Customer

	for rows.Next() {
		var c entity.Customer
		err := rows.Scan(
			&c.CustomerID,
			&c.CustomerFirstName,
			&c.CustomerLastName,
			&c.CustomerDocument,
			&c.CustomerPhone,
			&c.CustomerMobile,
			&c.CustomerAddressLine,
			&c.CustomerZipCode,
			&c.CustomerNeighborhood,
			&c.CustomerCity,
			&c.CustomerState,
			&c.CustomerCountry,
			&c.CustomerEmail,
			&c.CustomerAccountID,
			&c.CustomerStatus,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do cliente: %w", err)
		}
		customers = append(customers, &c)
	}

	return customers, nil
}

func (d *CustomerDatastore) SelectCustomerById(id int) (*entity.Customer, error) {
	query := `
		SELECT
			CustomerId,
			CustomerFirstName,
			CustomerLastName,
			CustomerDocument,
			CustomerPhone,
			CustomerMobile,
			CustomerAddressLine,
			CustomerZipCode,
			CustomerNeighborhood,
			CustomerCity,
			CustomerState,
			CustomerCountry,
			CustomerEmail,
			CustomerAccountID,
			CustomerStatus
		FROM Customers
		WHERE CustomerId = $1
	`

	var c entity.Customer

	err := d.Pool.QueryRow(context.Background(), query, id).Scan(
		&c.CustomerID,
		&c.CustomerFirstName,
		&c.CustomerLastName,
		&c.CustomerDocument,
		&c.CustomerPhone,
		&c.CustomerMobile,
		&c.CustomerAddressLine,
		&c.CustomerZipCode,
		&c.CustomerNeighborhood,
		&c.CustomerCity,
		&c.CustomerState,
		&c.CustomerCountry,
		&c.CustomerEmail,
		&c.CustomerAccountID,
		&c.CustomerStatus,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("cliente com id %d não encontrado", id)
		}
		return nil, fmt.Errorf("erro ao buscar cliente: %w", err)
	}

	return &c, nil
}

//Querie melhorada

func (d *CustomerDatastore) UpdateCustomer(customer *entity.Customer) (*entity.Customer, error) {
	query := `
		UPDATE Customers SET
			CustomerFirstName = $2,
			CustomerLastName = $3,
			CustomerDocument = $4,
			CustomerPhone = $5,
			CustomerMobile = $6,
			CustomerAddressLine = $7,
			CustomerZipCode = $8,
			CustomerNeighborhood = $9,
			CustomerCity = $10,
			CustomerState = $11,
			CustomerCountry = $12,
			CustomerEmail = $13,
			CustomerAccountID = $14,
			CustomerStatus = $15
		WHERE CustomerID = $1
		RETURNING
			CustomerID,
			CustomerFirstName,
			CustomerLastName,
			CustomerDocument,
			CustomerPhone,
			CustomerMobile,
			CustomerAddressLine,
			CustomerZipCode,
			CustomerNeighborhood,
			CustomerCity,
			CustomerState,
			CustomerCountry,
			CustomerEmail,
			CustomerAccountID,
			CustomerStatus
	`

	var c entity.Customer

	err := d.Pool.QueryRow(context.Background(), query,
		customer.CustomerID,
		customer.CustomerFirstName,
		customer.CustomerLastName,
		customer.CustomerDocument,
		customer.CustomerPhone,
		customer.CustomerMobile,
		customer.CustomerAddressLine,
		customer.CustomerZipCode,
		customer.CustomerNeighborhood,
		customer.CustomerCity,
		customer.CustomerState,
		customer.CustomerCountry,
		customer.CustomerEmail,
		customer.CustomerAccountID,
		customer.CustomerStatus,
	).Scan(
		&c.CustomerID,
		&c.CustomerFirstName,
		&c.CustomerLastName,
		&c.CustomerDocument,
		&c.CustomerPhone,
		&c.CustomerMobile,
		&c.CustomerAddressLine,
		&c.CustomerZipCode,
		&c.CustomerNeighborhood,
		&c.CustomerCity,
		&c.CustomerState,
		&c.CustomerCountry,
		&c.CustomerEmail,
		&c.CustomerAccountID,
		&c.CustomerStatus,
	)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("cliente com id %d não encontrado", customer.CustomerID)
		}
		return nil, fmt.Errorf("erro ao atualizar cliente: %w", err)
	}

	return &c, nil
}

func (d *CustomerDatastore) DeactivateCustomer(id int) error {
	query := `
		UPDATE Customers
		SET CustomerStatus = false
		WHERE CustomerID = $1
	`

	_, err := d.Pool.Exec(context.Background(), query, id)
	if err != nil {
		return fmt.Errorf("erro ao desativar cliente com id %d: %w", id, err)
	}

	return nil
}

func (d *CustomerDatastore) SelectCustomerByName(name string) ([]*entity.Customer, error) {

	query := `
		SELECT
			CustomerId,
			CustomerFirstName,
			CustomerLastName,
			CustomerDocument,
			CustomerPhone,
			CustomerMobile,
			CustomerAddressLine,
			CustomerZipCode,
			CustomerNeighborhood,
			CustomerCity,
			CustomerState,
			CustomerCountry,
			CustomerEmail,
			CustomerAccountID,
			CustomerStatus
		FROM Customers
		WHERE CustomerFirstName ILIKE $1
	`

	rows, err := d.Pool.Query(context.Background(), query, "%"+name+"%")
	if err != nil {
		return nil, fmt.Errorf("erro ao consultar clientes: %w", err)
	}

	var customers []*entity.Customer

	for rows.Next() {
		var c entity.Customer
		err := rows.Scan(
			&c.CustomerID,
			&c.CustomerFirstName,
			&c.CustomerLastName,
			&c.CustomerDocument,
			&c.CustomerPhone,
			&c.CustomerMobile,
			&c.CustomerAddressLine,
			&c.CustomerZipCode,
			&c.CustomerNeighborhood,
			&c.CustomerCity,
			&c.CustomerState,
			&c.CustomerCountry,
			&c.CustomerEmail,
			&c.CustomerAccountID,
			&c.CustomerStatus,
		)
		if err != nil {
			return nil, fmt.Errorf("erro ao ler linha do cliente: %w", err)
		}
		customers = append(customers, &c)
	}

	return customers, nil
}

func (d *CustomerDatastore) ValidateDocument(doc string) (*entity.Customer, error) {

	query := `
		SELECT
			CustomerId,
			CustomerFirstName,
			CustomerLastName,
			CustomerDocument
		FROM Customers
		WHERE CustomerDocument =  $1
	`
	var c entity.Customer

	err := d.Pool.QueryRow(context.Background(), query, doc).Scan(
		&c.CustomerID,
		&c.CustomerFirstName,
		&c.CustomerLastName,
		&c.CustomerDocument)

	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("cliente com documento %d não encontrado", c.CustomerID)
		}
		return nil, fmt.Errorf("erro ao buscar cliente: %w", err)
	}

	return &c, nil
}
