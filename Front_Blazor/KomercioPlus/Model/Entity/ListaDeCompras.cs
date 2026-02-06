using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KomercioPlus.Model.Entity
{
    public class ListaDeCompras
    {
        [Key]
        [JsonPropertyName("idListaCompra")]
        public int IdListaCompra { get; set; }
        [JsonPropertyName("nomeDaLista")]
        public string? NomeDaLista { get; set; }
        [JsonPropertyName("dataCriacaoLista")]
        public DateTimeOffset DataCriacaoLista { get; set; }
        [JsonPropertyName("statusLista")]
        public bool? StatusLista { get; set; }
    }
}