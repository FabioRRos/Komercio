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
	GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error)
	GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error)
}

type customertransactionService struct {
	repo repository.CustomertransactionRepository
}

func NewCustomertransactionService(repo repository.CustomertransactionRepository) CustomertransactionService {
	return &customertransactionService{repo: repo}
}

func (s *customertransactionService) CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error {

	if transaction == nil {
		return fmt.Errorf("Transação não pode ser nula")
	}
	return s.repo.CreateTransactionTX(ctx, tx, transaction)
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
