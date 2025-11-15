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
	//GETTransaction(ctx context.Context) ([]*entity.CustomerTransaction, error)
	//GETTransactionById(ctx context.Context, idtransaction int) ([]*entity.CustomerTransaction, error)
}

type customertransactionService struct {
	repo repository.CustomertransactionRepository
}

func NewCashmovementsService(repo repository.CustomertransactionRepository) CustomertransactionService {
	return &customertransactionService{repo: repo}
}

func (s *customertransactionService) CreateTransactionTX(ctx context.Context, tx pgx.Tx, transaction *entity.CustomerTransaction) error {

	if transaction == nil {
		return fmt.Errorf("Transação não pode ser nula")
	}
	return s.repo.CreateTransactionTX(ctx, tx, transaction)
}
