using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    internal class CashmovementsDTO
    {
        public class CashMovementsDTO
        {
            [JsonProperty("movement_id")]
            public int movementId { get; set; }

            [JsonProperty("sale_id")]
            public int saleId { get; set; }

            [JsonProperty("movement_type")]
            public string movementType { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("amount")]
            public float amount { get; set; }

            [JsonProperty("payment_method")]
            public string paymentMethod { get; set; }

            [JsonProperty("movement_datetime")]
            public DateTime movementDatetime { get; set; }

            [JsonProperty("seller_id")]
            public int sellerId { get; set; }
        }

    }
}
