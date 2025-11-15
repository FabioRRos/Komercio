package service

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

// Mesma lógica utilizada no repository (só muda o nome para Service)
type CashmovementService interface {
	CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) error
	SelectCashmovement(ctx context.Context) ([]*entity.Cashmovements, error)

	//  Novo método com suporte a transação
	// Serve para criar movimentação de caixa dentro de uma transação de venda.
	CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements) error
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
	if cashmovements == nil {
		return fmt.Errorf("movimentação de caixa não pode ser nula")
	}
	return s.repo.CreateCashmovement(ctx, cashmovements)
}

// Implementação da função CreateCashmovementTx
// Essa versão é usada quando a movimentação de caixa precisa acontecer junto com a venda e os itens.
// Se der erro em qualquer ponto, o rollback da transação cancela tudo.
func (s *cashmovementService) CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements) error {
	if cashmovements == nil {
		return fmt.Errorf("movimentação de caixa não pode ser nula")
	}
	return s.repo.CreateCashmovementTx(ctx, tx, cashmovements)
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
