using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    internal class SaleAggregateDTO
    {

        public SalesDTO Sales { get; set; }
        public List<SaleAggregateDTO> SalesItens { get; set; } 
        public CashmovementsDTO Cashmovements { get; set; }
    }
}
