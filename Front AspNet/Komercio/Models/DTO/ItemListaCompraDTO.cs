using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class ItemListaCompraDTO
    {
        [Key]
        [JsonPropertyName("IdItemCompra")]
        public int IdItemCompra { get; set; }
        [JsonPropertyName("IdLista")]
        public int IdLista { get; set; }
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
