using System;
using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class VendaRelatorio
    {
        [JsonPropertyName("saleid")]
        public int SaleId { get; set; }

        [JsonPropertyName("customername")]
        public string CustomerName { get; set; }

        [JsonPropertyName("CustomerDocument")]
        public string CustomerDocument { get; set; }


        [JsonPropertyName("sallername")]
        public string SellerName { get; set; }

        [JsonPropertyName("totalamount")]
        public decimal TotalAmount { get; set; } 

        [JsonPropertyName("discountamount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("finalamout")]
        public decimal FinalAmount { get; set; }

        [JsonPropertyName("saledate")]
        public DateTime SaleDate { get; set; }

        [JsonPropertyName("saletime")]
        public string SaleTime { get; set; }

        [JsonPropertyName("paymentmethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("salenotes")]
        public string SaleNotes { get; set; }
    }
}