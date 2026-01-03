using System.Text.Json.Serialization;

namespace Komercio.Models.DTO
{
    public class ProductsModel
    {
        [JsonPropertyName("id")]
        public int idProduct { get; set; }

        [JsonPropertyName("product_name")]
        public string productName { get; set; }

        [JsonPropertyName("product_price")]
        public float productPrice { get; set; }

        [JsonPropertyName("product_codbar")]
        public string productCodbar { get; set; }

        [JsonPropertyName("product_group")]
        public string productGroup { get; set; }

        [JsonPropertyName("product_subgroup")]
        public string productSubgroup { get; set; }

        [JsonPropertyName("product_stock")]
        public int productStock { get; set; }

        [JsonPropertyName("product_status")]
        public bool productStatus { get; set; }
    }
}
