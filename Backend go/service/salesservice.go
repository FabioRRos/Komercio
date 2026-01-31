package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5" // necessário para o tipo pgx.Tx
)

type SalesService interface {
	CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error)

	// novos métodos para transações
	BeginTransaction(ctx context.Context) (pgx.Tx, error)
	CreateNewSaleTx(ctx context.Context, tx pgx.Tx, sale *entity.Sales) (int, error)

	DeleteSaleCascade(ctx context.Context, saleId int) error
}

type salesService struct {
	repo    repository.SalesRepository
	service ProductService
}

func NewSalesService(repo repository.SalesRepository, service ProductService) SalesService {
	return &salesService{repo: repo, service: service}
}

// sem transação (já existia)
func (s *salesService) CreateNewSale(ctx context.Context, sale *entity.Sales) (int, error) {
	if sale == nil {
		return 0, errors.New("venda não pode ser nula")
	}
	return s.repo.CreateNewSale(ctx, sale)
}

// inicia uma transação (BEGIN)
func (s *salesService) BeginTransaction(ctx context.Context) (pgx.Tx, error) {
	return s.repo.BeginTransaction(ctx)
}

// cria a venda dentro de uma transação ativa
func (s *salesService) CreateNewSaleTx(ctx context.Context, tx pgx.Tx, sale *entity.Sales) (int, error) {
	if sale == nil {
		return 0, errors.New("venda não pode ser nula")
	}

	if sale.CustomerId == 0 {
		sale.CustomerId = 1
	}

	return s.repo.CreateNewSaleTx(ctx, tx, sale)
}

// ################################################# DELETAR VENDA EM CASCATA
func (s *salesService) DeleteSaleCascade(ctx context.Context, saleId int) error {

	if saleId <= 0 {
		return errors.New("ID da venda inválido")
	}

	// Busca a lista de produtos da venda para dar entrada novamente.

	err := s.service.GetCodbarBySaleId(ctx, saleId)

	if err != nil {
		return err
	}

	// Chama o repositório para deletar a venda em cascata
	return s.repo.DeleteSaleCascade(ctx, saleId)
}
