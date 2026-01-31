package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/infrastructure/clients"
)

type ListaCompraRepository interface {
	//gets
	ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ListarTodasAsListasAtivas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ListarTodasAsListasInativas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ObterListaPorId(ctx context.Context, id int) (*dto.ListaComprasDTO, error)

	//post
	CriarListaCompras(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error)

	//put

	AlterarListaDeCompra(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error)
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

func (r *listaCompraAPIRepository) ListarTodasAsListasAtivas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return r.client.ListarTodasAsListasAtivas(ctx)
}
func (r *listaCompraAPIRepository) ListarTodasAsListasInativas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return r.client.ListarTodasAsListasInativas(ctx)
}

func (r *listaCompraAPIRepository) ObterListaPorId(ctx context.Context, id int) (*dto.ListaComprasDTO, error) {
	return r.client.ObterListaPorId(ctx, id)
}

func (r *listaCompraAPIRepository) CriarListaCompras(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {
	return r.client.CriarListaCompras(ctx, lista)
}

func (r *listaCompraAPIRepository) AlterarListaDeCompra(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {
	return r.client.AlterarListaDeCompra(ctx, lista)
}
