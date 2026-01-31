package service

import (
	"context"
	"errors"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ParametrosService interface {
	GetAllParametros(ctx context.Context) ([]*entity.Parametros, error)
	UpdateParametros(ctx context.Context, parametro []*entity.Parametros) ([]*entity.Parametros, error)
}

type parametrosService struct {
	repo repository.ParametrosRepository
}

func NewParametrosService(repo repository.ParametrosRepository) ParametrosService {
	return &parametrosService{repo: repo}
}

func (s *parametrosService) GetAllParametros(ctx context.Context) ([]*entity.Parametros, error) {
	return s.repo.SelectAllParametros(ctx)
}

func (s *parametrosService) UpdateParametros(
	ctx context.Context,
	parametros []*entity.Parametros,
) ([]*entity.Parametros, error) {

	var parametrosRetorno []*entity.Parametros
	var falhouAlgum bool

	for _, par := range parametros {
		parametroAtualizado, err := s.repo.UpdateAllParametros(ctx, par)
		if err != nil {
			falhouAlgum = true
			continue
		}
		parametrosRetorno = append(parametrosRetorno, parametroAtualizado)
	}

	if len(parametrosRetorno) == 0 {
		return nil, errors.New("nenhum parâmetro foi atualizado")
	}

	if falhouAlgum {
		return parametrosRetorno, errors.New("alguns parâmetros não puderam ser atualizados")
	}

	return parametrosRetorno, nil
}
