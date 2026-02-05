using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomercioPlus.Model.DTO;

namespace KomercioPlus.Model.Entity
{
    public class Caixa
    {
        public class DashboardFinanceiroViewModel
        {
            public DateTime DataAtual { get; set; }
            public bool CaixaAberto { get; set; }

            // Cards Superiores
            public float SaldoInicial { get; set; }
            public float TotalEntradas { get; set; }
            public float TotalSaidas { get; set; }
            public float SaldoAtual { get; set; }

            // Lista para o Gráfico/Resumo lateral
            public List<ResumoPagamentoItem> ResumoPorFormaPagamento { get; set; } = new List<ResumoPagamentoItem>();

            // Lista para a Tabela Principal
            public List<MovimentacaoCaixaDTO> HistoricoMovimentacoes { get; set; } = new List<MovimentacaoCaixaDTO>();
        }


        public class ResumoPagamentoItem
        {
            public string? Forma { get; set; }
            public float Valor { get; set; }
        }
    }
}