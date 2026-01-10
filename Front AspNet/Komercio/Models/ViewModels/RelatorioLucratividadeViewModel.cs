using Komercio.Models.DTO;

namespace Komercio.Models.ViewModels
{
    public class RelatorioLucratividadeViewModel
    {
        // Lista bruta que vem do JSON do Go
        public List<LucratividadeModel> TodosOsItens { get; set; } = new();

        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        // Esta propriedade filtra os itens automaticamente antes de mandar para a tela
        public List<LucratividadeModel> ItensFiltrados
        {
            get
            {
                List<LucratividadeModel> itensFiltrados = new List<LucratividadeModel>();

                foreach (LucratividadeModel item in TodosOsItens)
                {
                    bool incluirItem = true;

                    // Verifica Data Inicial
                    if (DataInicial.HasValue)
                    {
                        if (item.SaleDate.Date < DataInicial.Value.Date)
                        {
                            incluirItem = false;
                        }
                    }

                    // Verifica Data Final
                    if (DataFinal.HasValue)
                    {
                        if (item.SaleDate.Date > DataFinal.Value.Date)
                        {
                            incluirItem = false;
                        }
                    }

                    // Se passou por todas as validações
                    if (incluirItem)
                    {
                        itensFiltrados.Add(item);
                    }
                }

                return itensFiltrados;
            }
        }

        // Agora as contas são feitas apenas sobre os ITENS FILTRADOS
        // Faturamento: Soma o valor FINAL da nota (uma vez por sale_id)
        public decimal FaturamentoTotal
        {
            get
            {
                decimal total = 0;

                // Lista para controlar quais vendas já foram somadas
                List<int> salesJaSomadas = new List<int>();

                foreach (LucratividadeModel item in ItensFiltrados)
                {
                    // Se essa venda ainda não foi considerada
                    if (!salesJaSomadas.Contains(item.SaleId))
                    {
                        // Soma o valor final da venda
                        total += item.FinalAmount;

                        // Marca essa venda como já processada
                        salesJaSomadas.Add(item.SaleId);
                    }
                }

                return total;
            }
        }

        // Custo Total: Soma o custo de cada item individual
        // Se houver repetição de sale_item_id no JSON, precisamos filtrar aqui também!
        public decimal CustoTotal
        {
            get
            {
                decimal total = 0;

                // Lista para controlar quais SaleItemId já foram considerados
                List<int> saleItemsJaProcessados = new List<int>();

                foreach (LucratividadeModel item in ItensFiltrados)
                {
                    // Se esse SaleItemId já foi processado, pula
                    if (saleItemsJaProcessados.Contains(item.SaleItemId))
                    {
                        continue;
                    }

                    // Marca como processado
                    saleItemsJaProcessados.Add(item.SaleItemId);

                    LucratividadeModel itemEscolhido = null;

                    // Procura dentro dos itens o primeiro com mesmo SaleItemId e custo > 0
                    foreach (LucratividadeModel candidato in ItensFiltrados)
                    {
                        if (candidato.SaleItemId == item.SaleItemId)
                        {
                            if (candidato.TotalPurchaseProduct > 0)
                            {
                                itemEscolhido = candidato;
                                break;
                            }

                            // Guarda o primeiro encontrado caso nenhum tenha custo > 0
                            if (itemEscolhido == null)
                            {
                                itemEscolhido = candidato;
                            }
                        }
                    }

                    // Soma o custo do item escolhido
                    if (itemEscolhido != null)
                    {
                        total += itemEscolhido.TotalPurchaseProduct;
                    }
                }

                return total;
            }
        }



        // Lucro Líquido: A conta real deve ser Faturamento - Custo
        // Ou a soma das margens (se a margem no Go estiver correta)
        public decimal LucroTotal => FaturamentoTotal - CustoTotal;
        public decimal PercentualMargem
        {
            get
            {
                decimal percentual = 0;

                if (FaturamentoTotal > 0)
                {
                    percentual = (LucroTotal / FaturamentoTotal) * 100;
                }
                else
                {
                    percentual = 0;
                }

                return percentual;
            }
        }
    }
}