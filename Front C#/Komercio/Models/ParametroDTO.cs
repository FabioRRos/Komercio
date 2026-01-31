using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ParametroDTO
    {
        [JsonProperty("parametroid")]
        public int Parametro_Id { get; set; }
        [JsonProperty("parametro_name")]
        public string Parametro_name { get; set; }
        [JsonProperty("status_parametro")]
        public bool Parametro_status { get; set; }
    }
}
