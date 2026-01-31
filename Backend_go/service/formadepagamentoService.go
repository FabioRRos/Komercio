package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type FormaPagamentoService interface {
	CreateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) error
	CreateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) error
	UpdateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error)
	UpdateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error)
	ReadFormaPagamentoById(ctx context.Context, id int) (*entity.FormaPagamento, error)
	ReadAllFormaPagamento(ctx context.Context) ([]*entity.FormaPagamento, error)
	DeleteFormaPagamentoById(ctx context.Context, id int) error
}

type formaPagamentoService struct {
	repo repository.FormaPagamentoRepository
}

func NewFormaPagamentoService(repo repository.FormaPagamentoRepository) FormaPagamentoService {
	return &formaPagamentoService{repo: repo}
}

func (s *formaPagamentoService) CreateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) error {

	validade := entity.ValidarCamposFormaPagamento(formaPagamento)
	if validade != nil {
		return validade
	}

	return s.repo.CreateFormaPagamento(ctx, formaPagamento)
}

func (s *formaPagamentoService) CreateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) error {
	validade := entity.ValidarCamposFormaPagamento(formaPagamento)
	if validade != nil {
		return validade
	}
	return s.repo.CreateFormaPagamentoTX(ctx, tx, formaPagamento)
}

func (s *formaPagamentoService) UpdateFormaPagamento(ctx context.Context, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	validade := entity.ValidarCamposFormaPagamento(formaPagamento)
	if validade != nil {
		return nil, validade
	}
	return s.repo.UpdateFormaPagamento(ctx, formaPagamento)
}

func (s *formaPagamentoService) UpdateFormaPagamentoTX(ctx context.Context, tx pgx.Tx, formaPagamento *entity.FormaPagamento) (*entity.FormaPagamento, error) {
	validade := entity.ValidarCamposFormaPagamento(formaPagamento)
	if validade != nil {
		return nil, validade
	}
	return s.repo.UpdateFormaPagamentoTX(ctx, tx, formaPagamento)
}

func (s *formaPagamentoService) ReadFormaPagamentoById(ctx context.Context, id int) (*entity.FormaPagamento, error) {
	return s.repo.ReadFormaPagamentoById(ctx, id)
}

func (s *formaPagamentoService) ReadAllFormaPagamento(ctx context.Context) ([]*entity.FormaPagamento, error) {
	return s.repo.ReadAllFormaPagamento(ctx)
}

func (s *formaPagamentoService) DeleteFormaPagamentoById(ctx context.Context, id int) error {
	return s.repo.DeleteFormaPagamentoById(ctx, id)
}
