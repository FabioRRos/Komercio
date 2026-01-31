using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class DescarteProdutoDTO
    {
        [JsonProperty("id_descarte")]
        public int Id { get; set; }
        [JsonProperty("codBarProduto")]
        public string CodBarProduto { get; set; }
        [JsonProperty("id_funcionario")]
        public int Id_funcionario { get; set; }
        [JsonProperty("justificativa")]
        public string Justificativa { get; set; }

    }
}
