using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class FormaPagamentoDTO
    {
        [JsonProperty("id_forma_pagamento", NullValueHandling = NullValueHandling.Ignore)]
        public int? IdFormaPagamento { get; set; }

        [JsonProperty("sale_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? SaleId { get; set; }

        [JsonProperty("forma_de_pagamento")]
        public string FormaDePagamento { get; set; }

        [JsonProperty("valor_pago")]
        public float ValorPago { get; set; }

        [JsonProperty("data_pagamento", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DataPagamento { get; set; }
    }

}
