using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ItemListaCompraDTO
    {
        [JsonProperty("IdItemCompra")]
        public int IdItemCompra { get; set; }
        [JsonProperty("IdLista")]
        public int IdLista { get; set; }
        [JsonProperty("DescricaoProduto")]
        public string DescricaoProduto { get; set; }
        [JsonProperty("CodBar")]
        public string CodBar { get; set; }
        [JsonProperty("Quantidade")]
        public int Quantidade { get; set; }
        [JsonProperty("StatusItem")]
        public bool StatusItem { get; set; }
        [JsonProperty("Obs")]
        public string Obs { get; set; }
    }





}
