using Komercio.Models;
using Komercio.Services; // Importante para achar a Interface
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Komercio.Services.RelatoriosService;

namespace Komercio.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatoriosService _relatoriosService;

        public RelatoriosController(IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
        }

        public IActionResult Index()
        {
            var menuOptions = new List<ReportMenuOption>
            {
                new ReportMenuOption {
                    Title = "Vendas por Período",
                    ActionName = "VendasPeriodo", // Isso deve bater com o nome do método abaixo
                    ControllerName = "Relatorios",
                    IconClass = "bi-calendar-date"
                },
                new ReportMenuOption {
                    Title = "Produtos Mais Vendidos",
                    ActionName = "ProdutosTop",
                    ControllerName = "Relatorios",
                    IconClass = "bi-graph-up-arrow"
                },
                new ReportMenuOption {
                    Title = "Baixo Estoque",
                    ActionName = "BaixoEstoque",
                    ControllerName = "Relatorios",
                    IconClass = "bi-exclamation-triangle"
                },
                new ReportMenuOption {
                    Title = "Movimentações Financeiras",
                    ActionName = "Financeiro",
                    ControllerName = "Relatorios",
                    IconClass = "bi-cash-coin"
                }
            };

            return View(menuOptions);
        }

        [HttpGet]
        public async Task<IActionResult> VendasPeriodo(DateTime? dataInicial, DateTime? dataFinal, string? vendedorSelecionado)
        {
            // 1. Busca todas as vendas 
            var todasAsVendas = await _relatoriosService.ListaDeVendaGeral();

            // todos os nomes, removemos duplicados e ordenamos
            var listaDeNomes = todasAsVendas
                                .Select(v => v.SellerName)
                                .Distinct()
                                .OrderBy(n => n)
                                .ToList();

            // 3. Aplica Filtros de Data 
            if (!dataInicial.HasValue)
            {
                dataInicial = DateTime.Today;
            }

            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Today;
            }


                var listaFiltrada = new List<VendaRelatorio>();
                var dataMinima = dataInicial.Value.Date;
                var dataMaxima = dataFinal.Value.Date;

                foreach (var venda in todasAsVendas)
                {
                if (venda.SaleDate.Date >= dataMinima && venda.SaleDate.Date <= dataMaxima)
                {
                    listaFiltrada.Add(venda);
                }
            }
                todasAsVendas = listaFiltrada;




            // 4. APLICA FILTRO DE VENDEDOR 
            if (!string.IsNullOrEmpty(vendedorSelecionado))
            {
                todasAsVendas = todasAsVendas.Where(v => v.SellerName == vendedorSelecionado).ToList();
            }

            // 5. Monta o ViewModel
            var viewModel = new RelatorioVendasViewModel
            {
                DataInicial = dataInicial,
                DataFinal = dataFinal,
                VendedorSelecionado = vendedorSelecionado, // Mantém a seleção na tela
                Vendas = todasAsVendas,

              
                ListaVendedores = listaDeNomes.Select(n => new SelectListItem
                {
                    Text = n,
                    Value = n,
                    Selected = n == vendedorSelecionado // Marca como selecionado se for o caso
                }).ToList()
            };

            return View(viewModel);
        }

        public IActionResult ProdutosTop() => View();
        public IActionResult BaixoEstoque() => View();
        public IActionResult Financeiro() => View();
    }
}