package service

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"

	"github.com/jackc/pgx/v5"
)

type CustomertransactionService interface {
	CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error
	CreateTransaction(ctx context.Context, transaction *entity.CustomerTransaction) error
	GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error)
	GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error)
}

type customertransactionService struct {
	repo repository.CustomertransactionRepository
	cash repository.CashmovementRepository
}

func NewCustomertransactionService(
	repo repository.CustomertransactionRepository,
	cash repository.CashmovementRepository,
) CustomertransactionService {
	return &customertransactionService{
		repo: repo,
		cash: cash,
	}
}

func (s *customertransactionService) CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error {

	if transaction == nil {
		return fmt.Errorf("Transação não pode ser nula")
	}

	return s.repo.CreateTransactionTX(ctx, tx, transaction)
}

/// Aqui temos a criação do evento de pagamento da conta

func (s *customertransactionService) CreateTransaction(ctx context.Context, transaction *entity.CustomerTransaction) error {

	if transaction == nil {
		return fmt.Errorf("Transação não pode ser nula")
	}

	err := entity.TransactionValidation(transaction)

	if err != nil {
		return err
	}
	transaction.Origin_type = "Pagamento"

	cashMovement := entity.Cashmovements{
		SalesId:                    transaction.Sale_id,
		Cashmovementstype:          "Entrada",
		Cashmovementsdescription:   transaction.Obs,
		Cashmovementsamount:        transaction.Transaction_value,
		Cashmovementspaymentmethod: transaction.Type_payment,
		Cashmovementsdatetime:      transaction.Transaction_date,
		SellerId:                   0,
	}
	err = s.cash.CreateCashmovement(ctx, &cashMovement)
	if err != nil {
		return err
	}
	return s.repo.CreateTransaction(ctx, transaction)
}

func (s *customertransactionService) GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error) {

	transactionList, err := s.repo.GETTransaction(ctx)

	if err != nil {
		return nil, fmt.Errorf("S - Não consegui retornar a lista. Tente mais tarde! ERROR: %w", err)
	}

	return transactionList, nil
}

func (s *customertransactionService) GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error) {

	if idtransaction <= 0 {
		return nil, fmt.Errorf("Id invalido ou não informado")
	}

	transactionList, err := s.repo.GETTransactionById(ctx, idtransaction)

	if err != nil {
		return nil, fmt.Errorf("Não consegui retornar a lista. Tente mais tarde!\nERROR: %w", err)
	}

	return transactionList, nil
}
