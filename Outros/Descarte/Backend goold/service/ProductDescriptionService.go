package service

import (
	"context"

	"github.com/fabioros/Komercio/domain/entity"
)

type ProductDescriptionService interface {
	FullListProductAndDescription(ctx context.Context) (*entity.ProductDescription, error)
}

type productDescriptionService struct {
	productService         ProductService
	productGroupService    ProductGroupService
	productSubgroupService ProductSubgroupService
}

func NewProductDescriptionService(
	product ProductService,
	group ProductGroupService,
	subgroup ProductSubgroupService,
) ProductDescriptionService {
	return &productDescriptionService{
		productService:         product,
		productGroupService:    group,
		productSubgroupService: subgroup,
	}
}

func (s *productDescriptionService) FullListProductAndDescription(ctx context.Context) (*entity.ProductDescription, error) {
	// Busca produtos
	products, err := s.productService.SelectAllProducts(ctx)
	if err != nil {
		return nil, err
	}

	// Busca grupos
	groups, err := s.productGroupService.SelectallProductGroup(ctx)
	if err != nil {
		return nil, err
	}

	// Busca subgrupos
	subgroups, err := s.productSubgroupService.SelectallProductSubgroup(ctx)
	if err != nil {
		return nil, err
	}

	// Converte []*entity.Product → []entity.Product
	var productValues []entity.Product
	for _, p := range products {
		productValues = append(productValues, *p)
	}

	// Converte []*entity.ProductGroup → []entity.ProductGroup
	var groupValues []entity.ProductGroup
	for _, g := range groups {
		groupValues = append(groupValues, *g)
	}

	// Converte []*entity.ProductSubGroup → []entity.ProductSubGroup
	var subgroupValues []entity.ProductSubGroup
	for _, sg := range subgroups {
		subgroupValues = append(subgroupValues, *sg)
	}

	// Monta a estrutura final
	result := &entity.ProductDescription{
		Product:  productValues,
		Group:    groupValues,
		Subgroup: subgroupValues,
	}

	return result, nil
}
