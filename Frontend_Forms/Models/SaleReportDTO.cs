using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Komercio.Models
{
    public class SaleReportDTO
    {

        [JsonProperty("saleid")]
        public int SaleId { get; set; }
        [JsonProperty("customername")]
        public string CustomerName { get; set; }
        [JsonProperty("CustomerDocument")]
        public string CustomerDocument {  get; set; }
        [JsonProperty("sallername")]
        public string SallerName { get; set; }
        [JsonProperty("totalamount")]
        public float TotalAmount { get; set; }
        [JsonProperty("discountamount")]
        public float DiscountAmount { get; set; }
        [JsonProperty("finalamout")]
        public float FinalAmount { get; set; }
        [JsonProperty("saledate")]
        public DateTime SaleDate { get; set; }
        [JsonProperty("saletime")]
        public string Saletime { get; set; }
        [JsonProperty("paymentmethod")]
        public string PaymantMethod { get; set; }
        [JsonProperty("salenotes")]
        public string SaleNotes { get; set; }


    }
}

