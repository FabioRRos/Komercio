using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class CupomDTO
    {
        [JsonProperty("salereport")]
        public SaleReportDTO SaleReport { get; set; }

        [JsonProperty("saleitens")]
        public List<SalesItensDTO> SaleItens { get; set; }

    }
}
