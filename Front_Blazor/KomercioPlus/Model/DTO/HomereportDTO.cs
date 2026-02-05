using System.Collections.Generic;
using System.Text.Json.Serialization;
using KomercioPlus.Model.Entity;

namespace KomercioPlus.Model.DTO
{
    public class HomereportDTO
    {
        [JsonPropertyName("Dinheiro")]
        public decimal Dinheiro { get; set; }

        [JsonPropertyName("Debito")]
        public decimal Debito { get; set; }

        [JsonPropertyName("Credito")]
        public decimal Credito { get; set; }

        [JsonPropertyName("Pix")]
        public decimal Pix { get; set; }

        [JsonPropertyName("Conta")]
        public decimal Conta { get; set; }
        [JsonPropertyName("TotalVendido")]
        public decimal TotalVendido { get; set; }
        [JsonPropertyName("TotalCaixa")]
        public decimal TotalCaixa { get; set; }
        [JsonPropertyName("MovimentacaoCaixa")]
        public List<MovimentacaoCaixa>? MovimentacaoCaixa { get; set; }
        [JsonPropertyName("Sales")]
        public List<SaleReport>? Sales { get; set; }
    }
}
