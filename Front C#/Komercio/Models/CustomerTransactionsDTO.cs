using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class CustomerTransactionsDTO
    {
        [JsonProperty("id_transaction")]
        public int IdTransaction { get; set; }

        [JsonProperty("sale_id")]
        public int SaleId { get; set; }

        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("origin_type")]
        public string OriginType { get; set; }

        [JsonProperty("transaction_value")]
        public float TransactionValue { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("obs")]
        public string Obs { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

        [JsonProperty("type_payment")]
        public string TypePayment { get; set; }
    }
}
