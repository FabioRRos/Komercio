using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class ListaComprasDTO
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
