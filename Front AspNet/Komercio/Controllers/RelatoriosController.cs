using Komercio.Models.DTO;
using Komercio.Models.ViewModels;
using Komercio.Services; // Importante para achar a Interface
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Komercio.Models;

namespace Komercio.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatoriosService _relatoriosService;
        private readonly IItensVendaService _itensVendaService;

        public RelatoriosController(IRelatoriosService relatoriosService, IItensVendaService itensVendaService)
        {
            _relatoriosService = relatoriosService;
            _itensVendaService = itensVendaService;
        }

        [Authorize]
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
                    Title = "Tipos Mais Vendidos", 
                    ActionName = "GruposMaisVendidos", 
                    ControllerName = "Relatorios",
                    IconClass = "bi-pie-chart-fill" 
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

        [HttpGet]
        public async Task<IActionResult> ProdutosTop(int? dias)
        {
            // --- PARTE 1: DEFINIR AS DATAS ---
            int diasFiltro = 30; // Padrão 30 dias se não vier nada

            if (dias.HasValue)
            {
                diasFiltro = dias.Value;
            }

            // Manda para a View saber qual botão pintar de azul
            ViewBag.DiasFiltro = diasFiltro;

            var dataInicio = DateTime.Today.AddDays(-diasFiltro);
            var dataFim = DateTime.Today;


            // --- PARTE 2: BUSCAR DADOS ---
            var todasAsVendas = await _relatoriosService.ListaDeVendaGeral();
            var todosOsItens = await _itensVendaService.ListaDeItensVenda();


            // --- PARTE 3: DESCOBRIR QUAIS VENDAS ESTÃO NO PRAZO ---
            // Vamos criar uma lista só com os IDs das vendas válidas (filtradas por data)
            var idsDasVendasValidas = new List<int>();

            foreach (var venda in todasAsVendas)
            {
                if (venda.SaleDate.Date >= dataInicio && venda.SaleDate.Date <= dataFim)
                {
                    idsDasVendasValidas.Add(venda.SaleId);
                }
            }


            // --- PARTE 4: SOMAR OS PRODUTOS ---
            // Vamos criar a lista final que vai para a tela
            var listaDeProdutosSomados = new List<TopProdutosViewModel>();

            foreach (var item in todosOsItens)
            {
                // PERGUNTA: Esse item pertence a uma das vendas válidas?
                // O método .Contains verifica se o ID da venda está na nossa lista de IDs filtrados
                if (idsDasVendasValidas.Contains(item.SaleId))
                {
                    // Se sim, vamos somar.
                    // Primeiro, verificamos se o produto JÁ está na nossa lista final
                    var produtoNaLista = listaDeProdutosSomados.FirstOrDefault(p => p.ProductId == item.ProductId);

                    if (produtoNaLista != null)
                    {
                        // CASO 1: O produto já existe na lista. Apenas somamos a quantidade e o valor.
                        produtoNaLista.QuantidadeTotal = produtoNaLista.QuantidadeTotal + item.Quantity;
                        produtoNaLista.ValorTotal = produtoNaLista.ValorTotal + item.Total;
                    }
                    else
                    {
                        // CASO 2: É a primeira vez que vemos esse produto. Criamos ele na lista.
                        var novoProduto = new TopProdutosViewModel
                        {
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            QuantidadeTotal = item.Quantity,
                            ValorTotal = item.Total
                        };
                        listaDeProdutosSomados.Add(novoProduto);
                    }
                }
            }

            // --- PARTE 5: ORDENAR (Do maior para o menor) ---
            // OrderByDescending = Do maior para o menor
            var listaOrdenada = listaDeProdutosSomados
                                .OrderByDescending(p => p.QuantidadeTotal)
                                .ToList();

            return View(listaOrdenada);
        }




        // Adicione na classe RelatoriosController

        [HttpGet]
        public async Task<IActionResult> GruposMaisVendidos(int? dias)
        {
            // --- 1. CONFIGURA DATA ---
            int diasFiltro = dias ?? 30;
            ViewBag.DiasFiltro = diasFiltro;

            var dataInicio = DateTime.Today.AddDays(-diasFiltro);
            var dataFim = DateTime.Today;

            // --- 2. BUSCA TODOS OS DADOS NECESSÁRIOS ---
            // Precisamos das 3 listas para cruzar as informações
            var todasVendas = await _relatoriosService.ListaDeVendaGeral();
            var todosItens = await _itensVendaService.ListaDeItensVenda();
            var todosProdutos = await _itensVendaService.ListaDeProdutos(); // <--- O NOVO MÉTODO

            // --- 3. FILTRA AS VENDAS PELA DATA ---
            var idsVendasValidas = new List<int>();
            foreach (var venda in todasVendas)
            {
                if (venda.SaleDate.Date >= dataInicio && venda.SaleDate.Date <= dataFim)
                {
                    idsVendasValidas.Add(venda.SaleId);
                }
            }

            // --- 4. CRUZA AS INFORMAÇÕES E SOMA POR GRUPO ---
            var listaGrupos = new List<GruposTopViewModel>();

            foreach (var item in todosItens)
            {
                // Só olha para o item se a venda estiver dentro da data
                if (idsVendasValidas.Contains(item.SaleId))
                {
                    // AGORA VEM O TRUQUE:
                    // Vamos procurar esse item vendido na lista de produtos completa para saber o GRUPO dele
                    // Usamos o ProductId para achar o idProduct
                    var produtoNoEstoque = todosProdutos.FirstOrDefault(p => p.idProduct == item.ProductId);

                    // Se achou o produto (segurança para não dar erro se o produto foi excluído)
                    if (produtoNoEstoque != null)
                    {
                        string nomeDoGrupo = produtoNoEstoque.productGroup; // Pega "Bebidas", "Ferramentas", etc.

                        // Verifica se já temos esse grupo na nossa lista de relatório
                        var grupoJaExiste = listaGrupos.FirstOrDefault(g => g.NomeGrupo == nomeDoGrupo);

                        if (grupoJaExiste != null)
                        {
                            // Se já existe, acumula
                            grupoJaExiste.QuantidadeTotal += item.Quantity;
                            grupoJaExiste.ValorTotal += item.Total;
                        }
                        else
                        {
                            // Se é novo, cria
                            listaGrupos.Add(new GruposTopViewModel
                            {
                                NomeGrupo = nomeDoGrupo,
                                QuantidadeTotal = item.Quantity,
                                ValorTotal = item.Total
                            });
                        }
                    }
                }
            }

            // --- 5. ORDENA DO MAIOR PARA O MENOR ---
            var listaOrdenada = listaGrupos.OrderByDescending(g => g.QuantidadeTotal).ToList();

            return View(listaOrdenada);
        }

        public IActionResult BaixoEstoque() => View();

        public async Task<IActionResult> Financeiro(DateTime? dataInicial, DateTime? dataFinal)
        {
            // Busca todas as vendas do serviço
            var todasAsVendas = await _relatoriosService.ValorCompraService();

            var viewModel = new RelatorioLucratividadeViewModel
            {
                TodasAsVendas = todasAsVendas,
                DataInicial = dataInicial,
                DataFinal = dataFinal
            };

            return View(viewModel);
        }






        // Endpoint que será chamado pelo botão "Ver Itens"
        [HttpGet]
        public async Task<IActionResult> ItensDaVenda(int saleId)
        {
            // 1. Busca TUDO (pois seu serviço traz tudo, lembra?)
            var todosOsItens = await _itensVendaService.ListaDeItensVenda();

            // 2. Filtra "na mão" apenas os itens da venda clicada
            var itensDestaVenda = new List<ItensVendaModel>();

            foreach (var item in todosOsItens)
            {
                // Verifica se o item pertence à venda que clicamos
                if (item.SaleId == saleId)
                {
                    itensDestaVenda.Add(item);
                }
            }

            // 3. Retorna uma "PartialView" (um pedaço de página) com a lista
            return PartialView("_ListaItensModal", itensDestaVenda);
        }
    }

}