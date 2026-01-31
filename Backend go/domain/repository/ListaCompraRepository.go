package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/infrastructure/clients"
)

type ListaCompraRepository interface {
	ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error)
}

type listaCompraAPIRepository struct {
	client *clients.ListaCompraAPIClient
}

func NewLListaCompraAPIRepository(apiClient *clients.ListaCompraAPIClient) ListaCompraRepository {
	return &listaCompraAPIRepository{
		client: apiClient,
	}
}

func (r *listaCompraAPIRepository) ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return r.client.ListarTodasAsListas(ctx)
}
