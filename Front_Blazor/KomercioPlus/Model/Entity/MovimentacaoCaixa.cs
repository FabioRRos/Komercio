using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KomercioPlus.Model.DTO;

namespace KomercioPlus.Model.Entity
{
    public class MovimentacaoCaixa
    {
        [JsonPropertyName("movement_id")]
        public int IdMovimento { get; set; }

        [JsonPropertyName("sale_id")]
        public int IdVenda { get; set; }

        [JsonPropertyName("movement_type")]
        public string? TipoMovimento { get; set; }

        [JsonPropertyName("description")]
        public string? Descricao { get; set; }

        [JsonPropertyName("amount")]
        public decimal Valor { get; set; }

        [JsonPropertyName("payment_method")]
        public string? FormaPagamento { get; set; }

        [JsonPropertyName("movement_datetime")]
        public DateTime DataHoraMovimento { get; set; }
        [JsonIgnore]
public string DataHoraMovimentoFormatado
{
    get
    {
        return DataHoraMovimento.ToLocalTime().ToString("HH:mm");
    }
}

        [JsonPropertyName("seller_id")]
        public int IdVendedor { get; set; }
    }
}