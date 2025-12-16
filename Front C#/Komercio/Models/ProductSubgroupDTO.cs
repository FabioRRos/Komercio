using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ProductSubgroupDTO
    {

        [JsonProperty("subgroup_id")]
        public int ProductsubgroupId { get; set; }
        [JsonProperty("subgroup_name")]
        public string ProductsubgroupName { get; set; }
        [JsonProperty("product_group_id")]
        public int Product_group_id { get; set; }
    }



}
