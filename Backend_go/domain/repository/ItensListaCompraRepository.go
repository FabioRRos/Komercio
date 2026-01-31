package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/infrastructure/clients"
)

type ItensListaCompraRepository interface {
	ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error)
	CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
	AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
}

type itensListaCompraRepository struct {
	client *clients.ItensListaCompraClients
}

func NewItensListaCompraRepository(apiClient *clients.ItensListaCompraClients) ItensListaCompraRepository {
	return &itensListaCompraRepository{
		client: apiClient,
	}
}

func (r *itensListaCompraRepository) ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error) {
	return r.client.ListarOsItensById(ctx, id)
}

func (r *itensListaCompraRepository) CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	return r.client.CriarItensListaDeCompra(ctx, item)
}

func (r *itensListaCompraRepository) AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error) {
	return r.client.AlterarItensListaDeCompra(ctx, item)
}
