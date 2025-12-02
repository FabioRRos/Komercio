package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type CaixaService interface {
	CaixaChangeTX(ctx context.Context, tx pgx.Tx, caixa *entity.Caixa) error
	CaixaChange(ctx context.Context, caixa *entity.Caixa) error
	GetCaixa(ctx context.Context) ([]*entity.Caixa, error)
}

type caixaService struct {
	repo repository.CaixaRepository
}

func NewCaixaService(repo repository.CaixaRepository) CaixaService {
	return &caixaService{repo: repo}
}

func (s *caixaService) CaixaChangeTX(ctx context.Context, tx pgx.Tx, caixa *entity.Caixa) error {
	err := s.repo.CaixaChangeTX(ctx, tx, caixa)
	if err != nil {
		return err
	}
	return nil
}

func (s *caixaService) CaixaChange(ctx context.Context, caixa *entity.Caixa) error {

	err := entity.ValidaCampos(caixa)

	if err != nil {
		return err
	}

	err = s.repo.CaixaChange(ctx, caixa)
	if err != nil {
		return err
	}
	return nil
}

func (s *caixaService) GetCaixa(ctx context.Context) ([]*entity.Caixa, error) {
	return s.repo.GetCaixa(ctx)
}
