package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

// Mesma lógica utilizada no repository (só muda o nome para Service)
type CashmovementService interface {
	CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) error
	SelectCashmovement(ctx context.Context) ([]*entity.Cashmovements, error)
}

// Estrutura que implementa a interface do CashmovementService

type cashmovementService struct {
	repo repository.CashmovementRepository
}

// Função que cria o serviço de Cashmovement
func NewCashmovementService(repo repository.CashmovementRepository) CashmovementService {
	return &cashmovementService{repo: repo}
}

// Implementação da função CreateCashmovement
func (s *cashmovementService) CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) error {
	return s.repo.CreateCashmovement(ctx, cashmovements)
}

// Implementação da função SelectCashmovement

// Aqui é onde nós temos as regras de negócio para selecionar os cashmovements
func (s *cashmovementService) SelectCashmovement(ctx context.Context) ([]*entity.Cashmovements, error) {

	cashmovements, err := s.repo.SelectCashmovement(ctx)
	if err != nil {
		return nil, err
	}
	return cashmovements, nil
}
