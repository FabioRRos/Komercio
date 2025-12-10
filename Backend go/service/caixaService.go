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

func NewCaixaService(
	repo repository.CaixaRepository,
	cashmovementService CashmovementService,
) CaixaService {
	return &caixaService{
		repo:                repo,
		cashMovementService: cashmovementService,
	}
}

type caixaService struct {
	repo                repository.CaixaRepository
	cashMovementService CashmovementService
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

	if caixa.ChangeOrigin == "Sangria" {

		var cash entity.Cashmovements
		cash.SalesId = 0
		cash.Cashmovementstype = caixa.ChangeType
		cash.Cashmovementsdescription = caixa.Observations
		cash.Cashmovementsamount = caixa.ValueChanged
		cash.Cashmovementspaymentmethod = caixa.ChangeOrigin
		cash.Cashmovementsdatetime = caixa.ChangeDate
		cash.SalesId = caixa.VendedorID

		err = s.cashMovementService.CreateCashmovement(ctx, &cash)
	}

	return nil
}

func (s *caixaService) GetCaixa(ctx context.Context) ([]*entity.Caixa, error) {

	return s.repo.GetCaixa(ctx)
}
