package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/repository"
)

type ItensListaCompraService interface {
	ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error)
	CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
	AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
}

type itensListaCompraService struct {
	repo repository.ItensListaCompraRepository
}

func NewItensListaCompraRepository(apiClient repository.ItensListaCompraRepository) ItensListaCompraService {
	return &itensListaCompraService{
		repo: apiClient,
	}
}

func (s *itensListaCompraService) ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error) {
	return s.repo.ListarOsItensById(ctx, id)
}

func (s *itensListaCompraService) CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	return s.repo.CriarItensListaDeCompra(ctx, item)
}

func (s *itensListaCompraService) AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	return s.repo.AlterarItensListaDeCompra(ctx, item)
}
