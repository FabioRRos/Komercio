using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class ValorCompraDto
{
    [JsonPropertyName("valor_compra")]
    public decimal ValorCompra { get; set; }
}

public class ProdutoDto
{
    [JsonPropertyName("product_id")]
    public int ProductID { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("unit_price")]
    public decimal UnitPrice { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("total")]
    public decimal Total { get; set; }

    [JsonPropertyName("costs")]
    public List<ValorCompraDto> Costs { get; set; } = new();
}

public class JsonVendaDto
{
    [JsonPropertyName("sale_id")]
    public int SaleID { get; set; }

    [JsonPropertyName("total_amount")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("sale_date")]
    public DateTime SaleDate { get; set; }

    [JsonPropertyName("payment")]
    public string Payment { get; set; } = string.Empty;

    [JsonPropertyName("sellerName")]
    public string SellerName { get; set; } = string.Empty;

    [JsonPropertyName("products")]
    public List<ProdutoDto> Products { get; set; } = new();
}
