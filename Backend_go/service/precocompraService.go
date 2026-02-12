package service

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/fabioros/Komercio/infrastructure/clients"
)

type PrecoCompraService interface {
	EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.Product) error
	SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error)
	UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error
	BaixarProdutosListaDePrecos(ctx context.Context, codBarras string, quantidade int) (float32, error)
	CreateValorCompraEVenda(ctx context.Context, valores []*dto.RealizarVendaDto) error
}

type precoCompraService struct {
	repo    repository.PrecoCompraRepository
	clients clients.ProdutosClient
}

func NewPrecoCompraService(repo repository.PrecoCompraRepository, clients clients.ProdutosClient) PrecoCompraService {
	return &precoCompraService{
		repo:    repo,
		clients: clients,
	}
}
func (s *precoCompraService) EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.Product) error {

	if produtoEntrada.ProductPrchasePrice <= 0 {
		precocompra, _ := s.repo.SelectItemEstoqueByCodbar(ctx, produtoEntrada.ProductCodBar)

		// Esse cara estava quebrando a lógica de valor = 0, atribuir valor de venda

		// if err != nil {
		// 	return fmt.Errorf("Não consegui buscar o ultimo valor - %w", err)
		// }
		produtoEntrada.ProductPrchasePrice = precocompra
	}

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
) (float32, error) {

	if quantidade <= 0 {
		return 0, errors.New("quantidade inválida")
	}

	restante := quantidade
	var valorTotalRetorno float32 = 0

	for restante > 0 {
		//Aqui eu busco a quantidade em estoque do
		produto, err := s.SelecEstoqueByCodbar(ctx, codBarras)
		if err != nil {
			return 0, fmt.Errorf("estoque insuficiente ou erro ao buscar produto: %w", err)
		}

		prodRetorn := entity.PrecoCompra{
			IDPrecoCompra: produto.IDPrecoCompra,
			CodigoBarras:  produto.CodigoBarras,
			ValorCompra:   produto.ValorCompra,
			Status:        produto.Status,
		}
		// aqui implanto o principio de FIFO.
		// sairá o que entrou primeiro.
		switch {
		case produto.Quantidade > restante:
			prodRetorn.Quantidade = produto.Quantidade - restante

			valorTotalRetorno += produto.ValorCompra * float32(restante)

			restante = 0
			prodRetorn.Status = true

		case produto.Quantidade == restante:
			prodRetorn.Quantidade = 0
			prodRetorn.Status = false

			valorTotalRetorno += produto.ValorCompra * float32(restante)

			restante = 0

		default:
			prodRetorn.Quantidade = 0
			prodRetorn.Status = false
			restante -= produto.Quantidade
			valorTotalRetorno += produto.ValorCompra * float32(produto.Quantidade)

		}

		if err := s.UpdateEstoqueCompra(ctx, prodRetorn); err != nil {
			return 0, err
		}
	}

	return valorTotalRetorno, nil
}

func (s *precoCompraService) CreateValorCompraEVenda(ctx context.Context, valor []*dto.RealizarVendaDto) error {

	for _, k := range valor {

		err := s.repo.CreateValorCompraEVenda(ctx, k)

		if err != nil {

			return err
		}
	}
	return nil
}
