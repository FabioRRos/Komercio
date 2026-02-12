package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/clients"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type PrecoCompraRepository interface {
	EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.PrecoCompra) error
	SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error)
	UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error
	SelectItemEstoqueByCodbar(ctx context.Context, codigoBarras string) (float32, error)
	CreateValorCompraEVenda(ctx context.Context, valores *dto.RealizarVendaDto) error
	GetValoresCompraVenda(ctx context.Context, saleId int) ([]*entity.DifValue, error)

	CriarFluxoDeVendaDoItem(ctx context.Context, item *dto.RealizarVendaDto) error
}

type precoCompraRepository struct {
	datastore *datastore.PrecoCompraDatastore
	clients   *clients.ProdutosClient
}

func NewPrecoCompraRepository(datastore *datastore.PrecoCompraDatastore, clients *clients.ProdutosClient) PrecoCompraRepository {
	return &precoCompraRepository{
		datastore: datastore,
		clients:   clients,
	}
}

func (r *precoCompraRepository) EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.PrecoCompra) error {
	return r.datastore.EntradaEstoqueCompraTX(ctx, produtoEntrada)
}

func (r *precoCompraRepository) SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error) {
	return r.datastore.SelecEstoqueByCodbar(ctx, codigobarras) // << esse cara
}

func (r *precoCompraRepository) UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error {
	return r.datastore.UpdateEstoqueCompra(ctx, produto)
}

func (r *precoCompraRepository) SelectItemEstoqueByCodbar(ctx context.Context, codigoBarras string) (float32, error) {
	return r.datastore.SelectItemEstoqueByCodbar(ctx, codigoBarras)
}

func (r *precoCompraRepository) CreateValorCompraEVenda(ctx context.Context, valor *dto.RealizarVendaDto) error {
	//return r.datastore.CreateValorCompraEVenda(ctx, valor)
	return r.clients.EntradaProdutosVenda(ctx, valor)
}
func (r *precoCompraRepository) GetValoresCompraVenda(ctx context.Context, saleId int) ([]*entity.DifValue, error) {
	return r.datastore.GetValoresCompraVenda(ctx, saleId)
}

func (r *precoCompraRepository) CriarFluxoDeVendaDoItem(ctx context.Context, item *dto.RealizarVendaDto) error {
	return r.clients.EntradaProdutosVenda(ctx, item)
}
