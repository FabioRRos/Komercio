using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace KomercioPlus.Model.Entity
{
    public class SaleReport
    {
         [JsonPropertyName("saleid")]
        public int SaleId { get; set; }

        [JsonPropertyName("customername")]
        public string CustomerName { get; set; }

        [JsonPropertyName("CustomerDocument")]
        public string CustomerDocument { get; set; }

        [JsonPropertyName("SallerName")]
        public string SallerName { get; set; }

        [JsonPropertyName("TotalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("FinalAmout")]
        public decimal FinalAmount { get; set; }

        [JsonPropertyName("SaleDate")]
        public DateTime SaleDate { get; set; }

        // Vem como "12:11:05.000000"
        [JsonPropertyName("SaleTime")]
        public string SaleTime { get; set; }

        [JsonPropertyName("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("SaleNotes")]
        public string SaleNotes { get; set; }
    }
}