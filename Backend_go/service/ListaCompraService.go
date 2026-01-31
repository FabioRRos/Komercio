package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/repository"
)

type ListaCompraAPIService interface {
	//get
	ListarTodasAsListas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ListarTodasAsListasAtivas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ListarTodasAsListasInativas(ctx context.Context) ([]dto.ListaComprasDTO, error)
	ObterListaPorId(ctx context.Context, id int) (*dto.ListaComprasDTO, error)

	//post
	CriarListaCompras(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error)

	//put
	AlterarListaDeCompra(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error)
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

// GET de todas as listas ativas de compra do banco (ativas ou inativas)
func (s *listaCompraAPIService) ListarTodasAsListasAtivas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return s.repo.ListarTodasAsListasAtivas(ctx)

} // GET de todas as listas inativas de compra do banco (ativas ou inativas)
func (s *listaCompraAPIService) ListarTodasAsListasInativas(ctx context.Context) ([]dto.ListaComprasDTO, error) {
	return s.repo.ListarTodasAsListasInativas(ctx)
}

func (s *listaCompraAPIService) ObterListaPorId(ctx context.Context, id int) (*dto.ListaComprasDTO, error) {
	return s.repo.ObterListaPorId(ctx, id)
}

func (s *listaCompraAPIService) CriarListaCompras(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {
	return s.repo.CriarListaCompras(ctx, lista)
}

func (s *listaCompraAPIService) AlterarListaDeCompra(ctx context.Context, lista *dto.ListaComprasDTO) (*dto.ListaComprasDTO, error) {

	return s.repo.AlterarListaDeCompra(ctx, lista)
}
