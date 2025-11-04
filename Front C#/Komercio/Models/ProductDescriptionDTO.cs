using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ProductDescriptionDTO
    {
        public List<ProductDTO> Product { get; set; }
        public List<ProductgroupDTO> Group { get; set; }
        public List<ProductSubgroupDTO> Subgroup { get; set; }
    }
}
