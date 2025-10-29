using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ProductgroupDTO
    {
        private readonly HttpClient _httpClient;

        [JsonProperty("group_id")]
        public int ProductgroupId { get; set; }
        [JsonProperty("group_name")]
        public string ProductgroupName { get; set; }
    }
}
