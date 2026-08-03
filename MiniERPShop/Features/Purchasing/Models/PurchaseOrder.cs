namespace MiniERPShop.Features.Purchasing.Models
{
    public class PurchaseOrder
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
        public DateTime PurchaseDate { get; set; } = DateTime.Now;
    }
}
