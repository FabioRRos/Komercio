using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KomercioPlus.Model.Entity
{
    public class ItensListaCompra
    {
        [Key]
        [JsonPropertyName("IdItemCompra")]
        public int IdItemCompra { get; set; }
        [JsonPropertyName("IdLista")]
        public int IdListaCompra { get; set; }
        [JsonPropertyName("DescricaoProduto")]
        public string? DescricaoProduto { get; set; }
        [JsonPropertyName("codbar")]
        public string? CodBar { get; set; }
        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }
        [JsonPropertyName("StatusItem")]
        public bool StatusItem { get; set; }
        [JsonPropertyName("Obs")]
        public string? Obs { get; set; }

    }
}