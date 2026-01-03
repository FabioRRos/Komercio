using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class MovimentacaoCaixaModel
    {
        [JsonPropertyName("movement_id")]
        public int movementId { get; set; }

        [JsonPropertyName("sale_id")]
        public int saleId { get; set; }

        [JsonPropertyName("movement_type")]
        public string MovementType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public float amount { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("movement_datetime")]
        public DateTime movementDatetime { get; set; }

        [JsonPropertyName("seller_id")]
        public int sellerId { get; set; }
    }
}
