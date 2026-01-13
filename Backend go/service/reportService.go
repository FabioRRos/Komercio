package service

import (
	"context"
	"fmt"
	"time"

	"github.com/fabioros/Komercio/domain/dto"
	"github.com/fabioros/Komercio/domain/entity"
	"github.com/fabioros/Komercio/domain/repository"
)

type ReportService interface {
	SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error)
	SelectSalesReportbyId(ctx context.Context, id int) (*entity.Salereport, error)
	SelectSales(ctx context.Context) ([]*entity.Sales, error)
	SelectItensSale(ctx context.Context, idVenda int) ([]*entity.SalesItens, error)
	SelectPrecoItensVenda(ctx context.Context, idVenda int) ([]*entity.DifValue, error)
	SelectActiveEmployeeNames(ctx context.Context) ([]*dto.EmployeeSimple, error)
	ReportSaleCoust(ctx context.Context) (*[]dto.JsonVenda, error)
}

type reportService struct {
	repo repository.ReportRepository
}

func NewSaleReportService(repo repository.ReportRepository) ReportService {
	return &reportService{repo: repo}
}

func (s *reportService) SelectSaleReport(ctx context.Context) ([]*entity.Salereport, error) {
	salereport, err := s.repo.SelectSaleReport(ctx)
	if err != nil {
		return nil, err
	}

	return salereport, err
}

func (s *reportService) SelectSalesReportbyId(ctx context.Context, id int) (*entity.Salereport, error) {
	salereport, err := s.repo.SelectSaleReportById(ctx, id)
	if err != nil {
		return nil, err
	}

	return salereport, err
}

// etapa 1
func (s *reportService) SelectSales(ctx context.Context) ([]*entity.Sales, error) {
	return s.repo.SelectSales(ctx)
}

// etapa 2
func (s *reportService) SelectItensSale(ctx context.Context, idVenda int) ([]*entity.SalesItens, error) {
	return s.repo.SelectItensSale(ctx, idVenda)
}

// etapa 3
func (s *reportService) SelectPrecoItensVenda(ctx context.Context, idVenda int) ([]*entity.DifValue, error) {
	return s.repo.SelectPrecoItensVenda(ctx, idVenda)
}

// etapa 4
func (s *reportService) SelectActiveEmployeeNames(ctx context.Context) ([]*dto.EmployeeSimple, error) {
	return s.repo.SelectActiveEmployeeNames(ctx)
}

// bora comentar que eu acabei de fazer e já estou quase esquecendo.
func (s *reportService) ReportSaleCoust(ctx context.Context) (*[]dto.JsonVenda, error) {
	//cria a estrutura do Json que vou enviar
	var JsonResult []dto.JsonVenda
	employers, err := s.SelectActiveEmployeeNames(ctx)
	//chama a venda
	vendas, err := s.SelectSales(ctx)

	if err != nil {
		return nil, err
	}
	//abre venda por venda pra eu pegar o Id
	for _, venda := range vendas {
		var json dto.JsonVenda

		json.SaleID = venda.SalesId
		json.TotalAmount = venda.TotalAmount

		//Aqui começa uma ajuste técnico para juntar data e hora.
		dateStr := venda.SalesDate.Format("2006-01-02")
		fullDateTimeStr := dateStr + " " + venda.SalesHour
		layout := "2006-01-02 15:04:05"

		saleTime, err := time.Parse(layout, fullDateTimeStr)
		if err != nil {
			return nil, fmt.Errorf("Erro ao converter: %w", err)
		}
		json.SaleDate = saleTime

		//Resolvido!

		json.Payment = venda.PaymentMethod
		//procuro o vendedor.
		for _, v := range employers {
			if v.ID == venda.SellerId {
				json.SellerName = v.Name
			}
		}
		produtos, err := s.SelectItensSale(ctx, venda.SalesId)
		if err != nil {
			return nil, err
		}

		lista, err := s.repo.SelectPrecoItensVenda(ctx, json.SaleID)
		if err != nil {
			return nil, err
		}
		//Abro um produto por vez da venda
		for n, produto := range produtos {
			var produtoTemp dto.Produto
			produtoTemp.ProductID = produto.ProductId
			produtoTemp.ProductName = produto.ProductName
			produtoTemp.UnitPrice = produto.UnitPrice
			produtoTemp.Quantity = produto.Quantity
			produtoTemp.Total = produto.Total

			//Pego os valores individuais de compra de cada um deles.
			for k, valor := range lista {
				var precoTemp dto.ValorCompra
				if k == n {
					precoTemp.ValorCompra = valor.PrecoCompra
				}

				if precoTemp.ValorCompra > 0 {

					produtoTemp.Costs = append(produtoTemp.Costs, precoTemp)
				}

			}

			json.Products = append(json.Products, produtoTemp)
		}
		JsonResult = append(JsonResult, json)
	}

	return &JsonResult, nil

}
