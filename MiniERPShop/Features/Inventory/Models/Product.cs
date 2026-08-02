namespace MiniERPShop.Features.Inventory.Models;

    public class Product
    {
        public int Id { get; set; }
        public string Code {  get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public int MinimumStock {  get; set; }
        public bool IsLowStock()
        {
            return StockQuantity <= MinimumStock;
        }
        public bool HasEnoughStock(int quantity)
        {
            return StockQuantity >= quantity;
        }
}

