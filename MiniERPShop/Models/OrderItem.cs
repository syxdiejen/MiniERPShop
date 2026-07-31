using MiniERPShop.Models;

public class OrderItem
{
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Total =>
        Product.SalePrice * Quantity;

    public decimal Cost =>
        Product.PurchasePrice * Quantity;
}