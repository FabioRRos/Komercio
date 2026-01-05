package service

import (
	"context"
	"errors"
	"fmt"

	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
	"github.com/jackc/pgx/v5"
)

type ProductService interface {
	CreateProduct(ctx context.Context, product *entity.Product) error
	CreateProductDescarte(ctx context.Context, productDescarte *entity.ProducrtDescarte) error
	SelectAllProducts(ctx context.Context) ([]*entity.Product, error)
	SelectProductById(ctx context.Context, id int) (*entity.Product, error)
	SelectProductByCodBar(ctx context.Context, productcodbar string) (*entity.Product, error)
	UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error)
	DeactivateProduct(ctx context.Context, id int) error
	UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int, precocompra float32) (*entity.Product, error)
	UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error
	SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error)
	UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error
	GetCodbarBySaleId(ctx context.Context, saleId int) error
}

type productService struct {
	repo repository.ProductRepository
	serv PrecoCompraService
}

func NewProductService(repo repository.ProductRepository, serv PrecoCompraService) ProductService {
	return &productService{
		repo: repo,
		serv: serv,
	}
}

func (s *productService) CreateProduct(ctx context.Context, product *entity.Product) error {
	if product == nil {
		return errors.New("produto não pode ser nulo")
	}

	if err := entity.ProductValidation(*product); err != nil {
		return err
	}

	codreturnet, err := s.repo.SelectProductByCodBar(ctx, product.ProductCodBar)

	if err == nil {
		return fmt.Errorf(
			"O código de barras já está atribuído ao produto '%s'. Informe outro ou deixe em branco para criarmos um novo.",
			codreturnet.ProductName,
		)
	}

	if product.ProductCodBar == "" {
		product.ProductCodBar = entity.CreateCodbar()
	}

	err = s.repo.Create(ctx, product)

	if err != nil {
		return fmt.Errorf("%w - Create", err)
	}

	err = s.serv.EntradaEstoqueCompraTX(ctx, product)

	return err
}

// CRIAR BAIXA DO PRODUTO E ATUALIZAR ESTOQUE

func (s *productService) CreateProductDescarte(ctx context.Context, productDescarte *entity.ProducrtDescarte) error {

	if productDescarte == nil {
		return fmt.Errorf("Descarte não pode ser nulo")
	}

	if productDescarte.CodBarProduto == "" {
		return fmt.Errorf("O código de barras não pode ser vazio!")
	}

	err := s.repo.UpdateProductOutputStock(ctx, productDescarte.CodBarProduto)

	if err != nil {
		return err
	}

	_, err = s.repo.SelectProductByCodBar(ctx, productDescarte.CodBarProduto)

	if err != nil {
		return fmt.Errorf("Código de barras não localizado")
	}

	err = s.repo.CreateProductDescarte(ctx, productDescarte)

	if err != nil {
		return err
	}

	err = s.serv.BaixarProdutosListaDePrecos(ctx, productDescarte.CodBarProduto, 1)

	return err
}

func (s *productService) SelectAllProducts(ctx context.Context) ([]*entity.Product, error) {
	products, err := s.repo.SelectAllProducts(ctx)
	if err != nil {
		return nil, err
	}

	// Filtra apenas produtos ativos
	var activeProducts []*entity.Product
	for _, p := range products {
		if p.ProductStatus {
			activeProducts = append(activeProducts, p)
		}
	}

	return activeProducts, nil
}

func (s *productService) SelectProductSettings(ctx context.Context) ([]*entity.ProductNotification, error) {
	products, err := s.repo.SelectProductSettings(ctx)

	if err != nil {
		return nil, err
	}

	return products, nil

}

func (s *productService) SelectProductById(ctx context.Context, id int) (*entity.Product, error) {
	if id <= 0 {
		return nil, errors.New("id inválido")
	}

	product, err := s.repo.SelectProductById(ctx, id)
	if err != nil {
		return nil, err
	}

	return product, nil
}

func (s *productService) SelectProductByCodBar(ctx context.Context, ProductcodBar string) (*entity.Product, error) {
	if ProductcodBar == "" {
		return nil, errors.New("Codigo de barras inválido")
	}

	product, err := s.repo.SelectProductByCodBar(ctx, ProductcodBar)
	if err != nil {
		return nil, err
	}

	return product, nil
}

func (s *productService) UpdateProduct(ctx context.Context, product *entity.Product) (*entity.Product, error) {
	if product == nil || product.Id <= 0 {
		return nil, errors.New("produto inválido para atualização")
	}

	if err := entity.ProductValidation(*product); err != nil {
		return nil, errors.New("parâmetros inválidos")
	}

	updated, err := s.repo.UpdateProduct(ctx, product)
	if err != nil {
		return nil, err
	}

	return updated, nil
}

func (s *productService) UpdateProductInputStock(ctx context.Context, productcodbar string, productStock int, precocompra float32) (*entity.Product, error) {
	update, err := s.repo.UpdateProductInputStock(ctx, productcodbar, productStock)
	if err != nil {
		return nil, err
	}

	updatePrecoProduct := update

	updatePrecoProduct.ProductStock = productStock
	updatePrecoProduct.ProductPrchasePrice = precocompra

	err = s.serv.EntradaEstoqueCompraTX(ctx, updatePrecoProduct)

	return update, err
}

func (s *productService) DeactivateProduct(ctx context.Context, id int) error {
	if id <= 0 {
		return errors.New("id inválido")
	}
	return s.repo.DeactivateProduct(ctx, id)
}

func (s *productService) UpdateProductOutputStockTX(ctx context.Context, tx pgx.Tx, productcodbar string, productStock int) error {

	if productcodbar == "" {
		return errors.New("código de barras inválido")
	}

	if productStock <= 0 {

		return errors.New(fmt.Errorf("Quantidade em estoque inválida %v", productStock).Error())
	}

	return s.repo.UpdateProductOutputStockTX(ctx, tx, productcodbar, productStock)
}

func (s *productService) UpdateProductNotification(ctx context.Context, productList []*entity.ProductNotification) error {

	if len(productList) == 0 {
		return fmt.Errorf("lista de produtos vazia")
	}

	for _, k := range productList {

		if k.Id_productNotification <= 0 {
			return fmt.Errorf("id inválido %d para o produto %s",
				k.Id_productNotification,
				k.Productname,
			)
		}

		if k.Productstock < 0 {
			return fmt.Errorf("estoque mínimo negativo (%d) no produto %s",
				k.Productstock, k.Productname)
		}
	}

	return s.repo.UpdateProductNotification(ctx, productList)
}

// devoluçao para o estoque (quando cancelar a venda)
func (s *productService) GetCodbarBySaleId(ctx context.Context, saleId int) error {
	if saleId <= 0 {
		return errors.New("ID da venda inválido")
	}
	listaCode, _ := s.repo.GetCodbarBySaleId(ctx, saleId)

	for _, k := range listaCode {

		s.UpdateProductInputStock(ctx, k.CodBar, k.Quantity, 0) //<- ARRUMAR AQUI DEPOIS FÁBIO!

	}
	return nil
}
