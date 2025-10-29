using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class SalesDTO
    {

        [JsonIgnore]
        public int SaleId { get; set; }
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("total_amount")]
        public float TotalAmount { get; set; }

        [JsonProperty("discount_amount")]
        public float DiscountAmount { get; set; }

        [JsonProperty("final_amount")]
        public float FinalAmount { get; set; }

        [JsonProperty("sale_date")]
        public DateTime SaleDate { get; set; }

        [JsonProperty("sale_time")]
        public string SaleTime { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("seller_id")]
        public int SellerId { get; set; }

        [JsonProperty("sale_notes")]
        public string SaleNotes { get; set; }


    }


}
