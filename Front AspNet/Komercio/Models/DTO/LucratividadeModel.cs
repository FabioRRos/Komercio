using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class LucratividadeModel
    {
        [JsonPropertyName("sale_id")]
        public int SaleId { get; set; }

        [JsonPropertyName("sale_item_id")]
        public int SaleItemId { get; set; }

        [JsonPropertyName("sale_date")]
        public DateTime SaleDate { get; set; }

        [JsonPropertyName("sale_time")]
        public string SaleTime { get; set; }

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        [JsonPropertyName("unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("total_sale_product")]
        public decimal TotalSaleProduct { get; set; }

        [JsonPropertyName("total_purchase_product")]
        public decimal TotalPurchaseProduct { get; set; }

        [JsonPropertyName("margin")]
        public decimal Margin { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("final_amount")]
        public decimal FinalAmount { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("seller_name")]
        public string SellerName { get; set; }
    }
 
}