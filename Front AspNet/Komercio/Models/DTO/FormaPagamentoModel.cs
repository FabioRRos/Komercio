using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class FormaPagamentoModel
    {
        [JsonPropertyName("id_forma_pagamento")]
        public int? IdFormaPagamento { get; set; }

        [JsonPropertyName("sale_id")]
        public int? SaleId { get; set; }

        [JsonPropertyName("forma_de_pagamento")]
        public string? FormaDePagamento { get; set; }

        [JsonPropertyName("valor_pago")]
        public float ValorPago { get; set; }

        [JsonPropertyName("data_pagamento")]
        public DateTime? DataPagamento { get; set; }
    }
}
