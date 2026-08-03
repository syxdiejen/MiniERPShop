namespace MiniERPShop.Features.Purchasing.DTOs
{
    public class PurchaseResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal TotalCost { get; set; }
    }
}
