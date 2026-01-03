namespace Komercio.Models.DTO;

using System.Text.Json.Serialization;

public class ItensVendaModel
{
    [JsonPropertyName("sale_item_id")]
    public int SaleItemId { get; set; }

    [JsonPropertyName("sale_id")]
    public int SaleId { get; set; }

    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("barcode")]
    public string Barcode { get; set; }

    [JsonPropertyName("unit_price")]
    public float UnitPrice { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("total")]
    public float Total { get; set; }

}
