using System;
using System.Collections.Generic;
using System.Linq;

namespace Komercio.Models.ViewModels
{
    public class RelatorioLucratividadeViewModel
    {
        // Lista bruta de vendas recebida do serviço
        public List<JsonVendaDto> TodasAsVendas { get; set; } = new();

        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        // Desdobra as vendas em itens individuais para a view
        public List<LucratividadeRelatorioItemDto> ItensFiltradosExpandida
        {
            get
            {
                var lista = new List<LucratividadeRelatorioItemDto>();
                if (TodasAsVendas == null) return lista;

                foreach (var venda in TodasAsVendas)
                {
                    if (DataInicial.HasValue && venda.SaleDate.Date < DataInicial.Value.Date)
                        continue;
                    if (DataFinal.HasValue && venda.SaleDate.Date > DataFinal.Value.Date)
                        continue;

                    int itemCounter = 1; // para criar SaleItemId único por venda
                    foreach (var produto in venda.Products)
                    {
                        decimal custoTotal = 0;
                        if (produto.Costs != null && produto.Costs.Any())
                        {
                            foreach (var custo in produto.Costs)
                                custoTotal += custo.ValorCompra;
                        }

                        lista.Add(new LucratividadeRelatorioItemDto
                        {
                            SaleId = venda.SaleID,
                            SaleItemId = venda.SaleID * 1000 + itemCounter, // garante ID único
                            SaleDate = venda.SaleDate,
                            SaleTime = venda.SaleDate.ToString("HH:mm"),
                            ProductName = produto.ProductName,
                            Quantity = produto.Quantity,
                            UnitPrice = produto.UnitPrice,
                            TotalSaleProduct = produto.Total,
                            TotalPurchaseProduct = custoTotal,
                            Margin = produto.Total - custoTotal,
                            FinalAmount = venda.TotalAmount,
                            SellerName = venda.SellerName,
                            PaymentMethod = venda.Payment
                        });

                        itemCounter++;
                    }
                }

                return lista;
            }
        }

        // Faturamento: soma apenas uma vez por venda
        public decimal FaturamentoTotal
        {
            get
            {
                decimal total = 0;
                var salesJaSomadas = new HashSet<int>();

                foreach (var item in ItensFiltradosExpandida)
                {
                    if (!salesJaSomadas.Contains(item.SaleId))
                    {
                        total += item.FinalAmount;
                        salesJaSomadas.Add(item.SaleId);
                    }
                }

                return total;
            }
        }

        // Custo total: soma o custo de cada item
        public decimal CustoTotal
        {
            get
            {
                decimal total = 0;
                var saleItemsJaProcessados = new HashSet<int>();

                foreach (var item in ItensFiltradosExpandida)
                {
                    // Evita duplicidade
                    if (saleItemsJaProcessados.Contains(item.SaleItemId))
                        continue;

                    saleItemsJaProcessados.Add(item.SaleItemId);
                    total += item.TotalPurchaseProduct;
                }

                return total;
            }
        }

        public decimal LucroTotal => FaturamentoTotal - CustoTotal;

        public decimal PercentualMargem
        {
            get
            {
                if (FaturamentoTotal > 0)
                    return (LucroTotal / FaturamentoTotal) * 100;
                return 0;
            }
        }
    }
}
