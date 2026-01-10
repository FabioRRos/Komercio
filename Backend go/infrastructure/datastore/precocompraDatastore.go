package datastore

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/jackc/pgx/v5/pgxpool"
)

type PrecoCompraDatastore struct {
	Pool *pgxpool.Pool
}

func NewPrecoCompraDatastore(pool *pgxpool.Pool) *PrecoCompraDatastore {

	return &PrecoCompraDatastore{Pool: pool}
}

// AQUI CRIAMOS A ENTRADA NO ESTOQUE COM O VALOR DA COMPRA.
func (d *PrecoCompraDatastore) EntradaEstoqueCompraTX(ctx context.Context, produtoEntrada *entity.PrecoCompra) error {

	query := `insert into valueproduct(
				codigobarras,
				valorcompra,
				quantidade,
				status,
				dataentrada,
				obs)
				values ($1, $2, $3, $4, $5, $6)`

	_, err := d.Pool.Exec(ctx, query,
		produtoEntrada.CodigoBarras,
		produtoEntrada.ValorCompra,
		produtoEntrada.Quantidade,
		produtoEntrada.Status,
		produtoEntrada.DataEntrada,
		produtoEntrada.Obs,
	)

	if err != nil {
		return fmt.Errorf("Erro ao adicionar o produto na tabela VALUEPRODUCT %w", err)
	}

	return nil
}

// AQUI BUSCAMOS O PRODUTO MAIS ANTIGO PARA REALIZAR A SAIDA DELE. FIRST IN FIRST OUT
func (d *PrecoCompraDatastore) SelecEstoqueByCodbar(ctx context.Context, codigobarras string) (*entity.PrecoCompra, error) {
	var produto entity.PrecoCompra

	query := `select id_preco_compra, codigobarras, valorcompra,quantidade from valueproduct v  where v.codigobarras = $1 and status = true  order by dataentrada asc limit 1 ;`

	err := d.Pool.QueryRow(ctx, query, codigobarras).Scan(
		&produto.IDPrecoCompra,
		&produto.CodigoBarras,
		&produto.ValorCompra,
		&produto.Quantidade,
	)

	if err != nil {
		return nil, fmt.Errorf("Erro ao buscar o produto na tabela VALUEPRODUCT")
	}

	return &produto, nil
}

// esse cara é apenas para retornar o ultimo valor cadastrado do produto.
// Dessa forma, caso não seja digitado o valor de compra, considerarei o ultimo cadastrado.
func (d *PrecoCompraDatastore) SelectItemEstoqueByCodbar(ctx context.Context, codigobarras string) (float32, error) {
	var preco float32 = 0

	query := `select valorcompra 
	from valueproduct v  
	where v.codigobarras = $1   
	order by dataentrada desc 
	limit 1 ;`

	err := d.Pool.QueryRow(ctx, query, codigobarras).Scan(
		&preco,
	)
	if err != nil {
		return 0, fmt.Errorf("Erro ao buscar o produto na tabela VALUEPRODUCT")
	}

	return preco, nil

}

// aqui eu atualizo o estoque de acordo com a necessidade.
func (d *PrecoCompraDatastore) UpdateEstoqueCompra(ctx context.Context, produto entity.PrecoCompra) error {

	query := `UPDATE valueProduct
SET
    quantidade = $1,
    status = $2
WHERE id_preco_compra = $3
  AND quantidade >= 0;`

	cmd, err := d.Pool.Exec(ctx, query, produto.Quantidade, produto.Status, produto.IDPrecoCompra)

	if err != nil {
		return fmt.Errorf("Erro ao atualizar o estoque na tabela VALUEPRODUCT")
	}

	if cmd.RowsAffected() == 0 {
		return errors.New("estoque já foi consumido por outra operação")
	}

	return nil
}

func (d *PrecoCompraDatastore) CreateValorCompraEVenda(ctx context.Context, valores *entity.DifValue) error {
	query := `INSERT Into valores_compra_venda(sale_id,
	valor_venda_produto,
	valor_compra_produto,
	product_id)
	VALUES($1,$2,$3,$4)`

	_, err := d.Pool.Exec(ctx, query,
		valores.Sale_id,
		valores.PrecoVenda,
		valores.PrecoCompra,
		valores.ProdictId,
	)

	if err != nil {
		return fmt.Errorf("Não pude salvar na tabela - %w", err)
	}

	return nil

}
