package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/repository"
)

type ListaCompraAPIService interface {
	ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error)
}

type listaCompraAPIService struct {
	repo repository.ListaCompraRepository
}

func NewListaCompraAPIService(repo repository.ListaCompraRepository) ListaCompraAPIService {
	return &listaCompraAPIService{
		repo: repo,
	}
}

// GET de todas as listas de compra do banco (ativas ou inativas)
func (s *listaCompraAPIService) ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return s.repo.ListarTodasAsListas(ctx)
}
