package service

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type PrecoCompraService interface {
	EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.Product) error
	SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error)
	UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error
	BaixarProdutosListaDePrecos(ctx context.Context, codBarras string, quantidade int) error
}

type precoCompraService struct {
	repo repository.PrecoCompraRepository
}

func NewPrecoCompraService(repo repository.PrecoCompraRepository) PrecoCompraService {
	return &precoCompraService{repo: repo}
}
func (s *precoCompraService) EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.Product) error {

	produtoEntradaPreco, err := entity.ProductToPrecocompra(produtoEntrada)

	if err != nil {
		return err
	}
	return s.repo.EntradaEstoqueCompraTX(ctx, produtoEntradaPreco)

}
func (s *precoCompraService) SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error) {
	return s.repo.SelecEstoqueByCodbar(ctx, codigobarras)
}

func (s *precoCompraService) UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error {
	return s.repo.UpdateEstoqueCompra(ctx, produto)
}

func (s *precoCompraService) BaixarProdutosListaDePrecos(
	ctx context.Context,
	codBarras string,
	quantidade int,
) error {

	if quantidade <= 0 {
		return errors.New("quantidade inválida")
	}

	restante := quantidade

	for restante > 0 {

		produto, err := s.SelecEstoqueByCodbar(ctx, codBarras)
		if err != nil {
			return fmt.Errorf("estoque insuficiente ou erro ao buscar produto: %w", err)
		}

		prodRetorn := entity.PrecoCompra{
			IDPrecoCompra: produto.IDPrecoCompra,
			CodigoBarras:  produto.CodigoBarras,
			ValorCompra:   produto.ValorCompra,
			Status:        produto.Status,
		}

		switch {
		case produto.Quantidade > restante:
			prodRetorn.Quantidade = produto.Quantidade - restante
			restante = 0
			prodRetorn.Status = true

		case produto.Quantidade == restante:
			prodRetorn.Quantidade = 0
			prodRetorn.Status = false
			restante = 0

		default:
			prodRetorn.Quantidade = 0
			prodRetorn.Status = false
			restante -= produto.Quantidade
		}

		if err := s.UpdateEstoqueCompra(ctx, prodRetorn); err != nil {
			return err
		}
	}

	return nil
}
