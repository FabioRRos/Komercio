package repository

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/infrastructure/datastore"
)

type PrecoCompraRepository interface {
	EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.PrecoCompra) error
	SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error)
	UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error
	SelectItemEstoqueByCodbar(ctx context.Context, codigoBarras string) (float32, error)
	CreateValorCompraEVenda(ctx context.Context, valores *entity.DifValue) error
	GetValoresCompraVenda(ctx context.Context, saleId int) ([]*entity.DifValue, error)
}

type precoCompraRepository struct {
	datastore *datastore.PrecoCompraDatastore
}

func NewPrecoCompraRepository(datastore *datastore.PrecoCompraDatastore) PrecoCompraRepository {
	return &precoCompraRepository{datastore: datastore}
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

func (r *precoCompraRepository) CreateValorCompraEVenda(ctx context.Context, valor *entity.DifValue) error {
	return r.datastore.CreateValorCompraEVenda(ctx, valor)
}
func (r *precoCompraRepository) GetValoresCompraVenda(ctx context.Context, saleId int) ([]*entity.DifValue, error) {
	return r.datastore.GetValoresCompraVenda(ctx, saleId)
}
