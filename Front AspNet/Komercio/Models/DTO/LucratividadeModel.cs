public class LucratividadeRelatorioItemDto
{
    public int SaleId { get; set; }
    public int SaleItemId { get; set; }
    public DateTime SaleDate { get; set; }
    public string SaleTime { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalSaleProduct { get; set; }
    public decimal TotalPurchaseProduct { get; set; }
    public decimal Margin { get; set; }
    public decimal FinalAmount { get; set; }
    public string SellerName { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
}
