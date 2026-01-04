using Komercio.Models;
using Komercio.Models.DTO;
using Komercio.Models.ViewModels;
using Komercio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Komercio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRelatoriosService _relatoriosService;

        // INJEÇÃO DE DEPENDÊNCIA
        // O construtor recebe o serviço para podermos buscar os dados
        public HomeController(IRelatoriosService relatoriosService)
        {
            _relatoriosService = relatoriosService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                //Define a data de hoje
                DateTime dataDeHoje = DateTime.Today;

                // Busca os dados brutos
                var todasAsMovimentacoes = await _relatoriosService.MovimentacaoCaixa();
                var todosDetalhesPagamento = await _relatoriosService.FormaPagamento();

                // Filtra apenas o que aconteceu HOJE
                List<MovimentacaoCaixaModel> movimentacoesDoDiaAtual = new List<MovimentacaoCaixaModel>();

                foreach (var movimentacao in todasAsMovimentacoes)
                {
                    if (movimentacao.movementDatetime.Date == dataDeHoje)
                    {
                        movimentacoesDoDiaAtual.Add(movimentacao);
                    }
                }

                // CÁLCULO DOS CARDS SUPERIORES 
                float saldoInicial = 0;
                float totalEntradas = 0;
                float totalSaidas = 0;

                foreach (var movimentacao in movimentacoesDoDiaAtual)
                {
                    // Lógica do Saldo Inicial
                    if (movimentacao.PaymentMethod == "Abertura")
                    {
                        saldoInicial = saldoInicial + movimentacao.amount;
                    }

                    // Lógica das Entradas (Exclui abertura)
                    if (movimentacao.MovementType.ToLower() == "entrada" && movimentacao.PaymentMethod != "Abertura")
                    {
                        totalEntradas = totalEntradas + movimentacao.amount;
                    }

                    // Lógica das Saídas
                    if (movimentacao.MovementType.ToLower() == "retirada" || movimentacao.MovementType.ToLower() == "saida")
                    {
                        totalSaidas = totalSaidas + movimentacao.amount;
                    }
                }

                //Status do Caixa 
                bool caixaEstaAberto = false;

                if (movimentacoesDoDiaAtual.Count <= 0)
                {
                    caixaEstaAberto = false;
                }



                if (movimentacoesDoDiaAtual.Count >= 0)
                {
                    // Pega o último item da lista pelo índice (Total - 1)
                    int indiceDoUltimoItem = movimentacoesDoDiaAtual.Count - 1;
                    MovimentacaoCaixaModel ultimaMovimentacao = movimentacoesDoDiaAtual[indiceDoUltimoItem];

                    if (ultimaMovimentacao.PaymentMethod == "Fechamento")
                    {
                        caixaEstaAberto = false;
                    }
                    else if (ultimaMovimentacao.PaymentMethod == "Abertura")
                    {
                        caixaEstaAberto = true;
                    }

                }


                

                // LÓGICA DE FORMAS DE PAGAMENTO
                Dictionary<string, float> dicionarioResumoPagamento = new Dictionary<string, float>();

                foreach (var movimentacao in movimentacoesDoDiaAtual)
                {
                    // Verifica se é uma Entrada financeira válida
                    if (movimentacao.MovementType.ToLower() == "entrada" && movimentacao.PaymentMethod != "Abertura")
                    {
                        // INÍCIO DA BUSCA MANUAL DOS DETALHES 
                        List<FormaPagamentoModel> detalhesEncontrados = new List<FormaPagamentoModel>();

                        foreach (var detalhe in todosDetalhesPagamento)
                        {
                            // O sale_id do detalhe deve bater com o movement_id da movimentação
                            if (detalhe.SaleId == movimentacao.movementId)
                            {
                                detalhesEncontrados.Add(detalhe);
                            }
                        }
                        // -- FIM DA BUSCA MANUAL --

                        if (detalhesEncontrados.Count > 0)
                        {
                            // CENÁRIO A: Encontrou detalhes (Venda Mista ou detalhada)
                            foreach (var detalhe in detalhesEncontrados)
                            {
                                string nomeFormaPagamento = "Outros";

                                if (detalhe.FormaDePagamento != null)
                                {
                                    nomeFormaPagamento = detalhe.FormaDePagamento;
                                }

                                if (dicionarioResumoPagamento.ContainsKey(nomeFormaPagamento))
                                {
                                    dicionarioResumoPagamento[nomeFormaPagamento] += detalhe.ValorPago;
                                }
                                else
                                {
                                    dicionarioResumoPagamento.Add(nomeFormaPagamento, detalhe.ValorPago);
                                }
                            }
                        }
                        else
                        {
                            // CENÁRIO B: Não tem detalhe, usa a forma da movimentação principal
                            string nomeFormaPagamento = movimentacao.PaymentMethod;

                            if (dicionarioResumoPagamento.ContainsKey(nomeFormaPagamento))
                            {
                                dicionarioResumoPagamento[nomeFormaPagamento] += movimentacao.amount;
                            }
                            else
                            {
                                dicionarioResumoPagamento.Add(nomeFormaPagamento, movimentacao.amount);
                            }
                        }
                    }
                }

                // PREPARAR LISTAS FINAIS PARA O VIEWMODEL

                // Inverte a lista de movimentações para mostrar a mais recente primeiro 
                movimentacoesDoDiaAtual.Reverse();

                // Converte o Dicionário para Lista manualmente
                List<ResumoPagamentoItem> listaResumoPagamentos = new List<ResumoPagamentoItem>();

                foreach (KeyValuePair<string, float> itemDoDicionario in dicionarioResumoPagamento)
                {
                    ResumoPagamentoItem novoItem = new ResumoPagamentoItem();
                    novoItem.Forma = itemDoDicionario.Key;
                    novoItem.Valor = itemDoDicionario.Value;

                    listaResumoPagamentos.Add(novoItem);
                }

                // 8. Monta o ViewModel
                DashboardFinanceiroViewModel viewModel = new DashboardFinanceiroViewModel();
                viewModel.DataAtual = dataDeHoje;
                viewModel.CaixaAberto = caixaEstaAberto;
                viewModel.SaldoInicial = saldoInicial;
                viewModel.TotalEntradas = totalEntradas;
                viewModel.TotalSaidas = totalSaidas;
                viewModel.HistoricoMovimentacoes = movimentacoesDoDiaAtual;
                viewModel.ResumoPorFormaPagamento = listaResumoPagamentos;

                return View(viewModel);
            }
            catch (Exception)
            {
                // Retorno de erro limpo
                DashboardFinanceiroViewModel viewModelVazio = new DashboardFinanceiroViewModel();
                viewModelVazio.DataAtual = DateTime.Today;
                viewModelVazio.HistoricoMovimentacoes = new List<MovimentacaoCaixaModel>();

                return View(viewModelVazio);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}