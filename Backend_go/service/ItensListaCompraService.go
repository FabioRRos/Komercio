package service

import (
	"context"
	"fmt"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/repository"
)

type ItensListaCompraService interface {
	ListarOsItensById(ctx context.Context, id int) (*[]dto.ItensListaCompraDTO, error)
	CriarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
	AlterarItensListaDeCompra(ctx context.Context, item *dto.ItensListaCompraDTO) (*dto.ItensListaCompraDTO, error)
	TratamentoListaCompra(ctx context.Context, listaItens []dto.ItensListaCompraDTO) ([]dto.ItensListaCompraDTO, error)
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

func (s *itensListaCompraService) TratamentoListaCompra(ctx context.Context, listaItens []dto.ItensListaCompraDTO) ([]dto.ItensListaCompraDTO, error) {
	var listaRetorno []dto.ItensListaCompraDTO

	var erro error

	for _, k := range listaItens {
		var ret *dto.ItensListaCompraDTO
		var err error

		//Valido se ele tem ID, Se tiver é edição, se não tiver é criação
		if k.IdItemCompra == 0 {
			ret, err = s.repo.CriarItensListaDeCompra(ctx, &k)
		} else {
			ret, err = s.repo.AlterarItensListaDeCompra(ctx, &k)
		}
		//Valido se tive algum erro no teronro.
		if err != nil {
			erro = err
			//garanto que, se ret == nil, eu tenha espaço na memória pra armazenar a mensagem abaixo.
			ret = &dto.ItensListaCompraDTO{
				IdItemCompra: k.IdItemCompra,
			}
			if k.IdItemCompra == 0 { //Como dito, se zero é novo então o ENUM será 001 - criação
				ret.DescricaoProduto = fmt.Sprintf("001-%s", k.DescricaoProduto)
			} else { // se for diferente de zero é edição então o ENUM será 002 - Edição.
				ret.DescricaoProduto = fmt.Sprintf("002-ERROR-%s", k.DescricaoProduto)
			}
		}

		listaRetorno = append(listaRetorno, *ret) // Adiciona o array de retorno.
	}
	return listaRetorno, erro // retorna. Se pelo menos um item tiver erro, eu sei que teve e consigo tratar isso.
}
