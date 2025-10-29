using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    internal class SaleAggregateDTO
    {
        public SaleAggregateDTO(SalesDTO sales, List<SalesItensDTO> salesItens, CashovementsDTO cashmovements)
        {
            Sales = sales;
            SalesItens = salesItens;
            Cashmovements = cashmovements;
        }
        [JsonProperty("sale")]
        public SalesDTO Sales { get; set; }
        [JsonProperty("items")]
        public List<SalesItensDTO> SalesItens { get; set; }
        [JsonProperty("cash_movement")]
        public CashovementsDTO Cashmovements { get; set; }
    }
}
