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
	CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements, formaPagamento []*entity.FormaPagamento) error
}

// Estrutura que implementa a interface do CashmovementService
type cashmovementService struct {
	repo                  repository.CashmovementRepository
	forma                 repository.FormaPagamentoRepository
	formaPagamentoService FormaPagamentoService
}

// Função que cria o serviço de Cashmovement
func NewCashmovementService(repo repository.CashmovementRepository, forma repository.FormaPagamentoRepository, formaPagamentoService FormaPagamentoService) CashmovementService {
	return &cashmovementService{repo: repo, forma: forma, formaPagamentoService: formaPagamentoService}
}

func (s *cashmovementService) CreateCashmovement(ctx context.Context, cashmovements *entity.Cashmovements) error {

	if cashmovements == nil {
		return fmt.Errorf("movimentação de caixa não pode ser nula")
	}

	id, err := s.repo.CreateCashmovement(ctx, cashmovements)
	if err != nil {
		return err
	}

	cashmovements.Cashmovementsid = id

	if cashmovements.Cashmovementspaymentmethod != "Sangria" &&
		cashmovements.Cashmovementspaymentmethod != "Abertura" &&
		cashmovements.Cashmovementspaymentmethod != "Fechamento" {

		formaPagamentoRecord := entity.FormaPagamento{
			Sale_id:            cashmovements.Cashmovementsid,
			Forma_de_pagamento: cashmovements.Cashmovementspaymentmethod,
			Valor_pago:         cashmovements.Cashmovementsamount,
			Data_pagamento:     cashmovements.Cashmovementsdatetime,
		}

		err = s.formaPagamentoService.CreateFormaPagamento(ctx, &formaPagamentoRecord)

		if err != nil {
			return err
		}
	}
	return nil

}

// Implementação da função CreateCashmovementTx
// Essa versão é usada quando a movimentação de caixa precisa acontecer junto com a venda e os itens.
// Se der erro em qualquer ponto, o rollback da transação cancela tudo.
func (s *cashmovementService) CreateCashmovementTx(ctx context.Context, tx pgx.Tx, cashmovements *entity.Cashmovements, formaPagamento []*entity.FormaPagamento) error {

	if cashmovements == nil {
		return fmt.Errorf("movimentação de caixa não pode ser nula")
	}

	// Primeiro cria a movimentação de caixa
	id, err := s.repo.CreateCashmovementTx(ctx, tx, cashmovements)
	if err != nil {
		return err
	}

	// Garante que o ID fique no objeto
	cashmovements.Cashmovementsid = id

	// Depois cria as formas de pagamento vinculadas à movimentação
	for _, forma := range formaPagamento {

		formaPagamentoRecord := entity.FormaPagamento{
			Sale_id:            cashmovements.Cashmovementsid,
			Forma_de_pagamento: forma.Forma_de_pagamento,
			Valor_pago:         forma.Valor_pago,
			Data_pagamento:     cashmovements.Cashmovementsdatetime,
		}

		if err := s.forma.CreateFormaPagamentoTX(ctx, tx, &formaPagamentoRecord); err != nil {
			return fmt.Errorf("erro ao salvar forma de pagamento: %w", err)
		}
	}

	return nil
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
