using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{

        public class CaixaModel
        {
            [JsonPropertyName("id_transiction")]
            public int IDTransiction { get; set; }
            [JsonPropertyName("value_changed")]
            public float ValueChanged { get; set; }
            [JsonPropertyName("change_type")]
            public string ChangeType { get; set; }
            [JsonPropertyName("change_origin")]
            public string ChangeOrigin { get; set; }
            [JsonPropertyName("change_date")]
            public DateTime ChangeDate { get; set; }
            [JsonPropertyName("vendedor_id")]
            public int VendedorID { get; set; }
            [JsonPropertyName("status")]
            public bool Status { get; set; }
            [JsonPropertyName("observations")]
            public string Observations { get; set; }
        }
}

