using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KomercioPlus.Model.DTO
{
    public class MovimentacaoCaixaDTO
    {
        [JsonPropertyName("movement_id")]
        public int MovementId { get; set; }

        [JsonPropertyName("sale_id")]
        public int SaleId { get; set; }

        [JsonPropertyName("movement_type")]
        public string? MovementType { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("payment_method")]
        public string? PaymentMethod { get; set; }

        [JsonPropertyName("movement_datetime")]
        public DateTime MovementDatetime { get; set; }

        [JsonPropertyName("seller_id")]
        public int SellerId { get; set; }
    }
}