using MiniERPShop.Features.Inventory.Models;

namespace MiniERPShop.Features.Inventory.Services;

public class InventoryService
{
    private readonly List<Product> _products;

    public InventoryService(List<Product> products)
    {
        _products = products;
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _products.AsReadOnly();
    }

    public Product? GetProductById(int productId)
    {
        return _products.FirstOrDefault(p => p.Id == productId);
    }

    public bool IsLowStock(Product product)
    {
        return product.StockQuantity <= product.MinimumStock;
    }

    public bool AddStock(int productId, int quantity)
    {
        Product? product = GetProductById(productId);

        if (product is null || quantity <= 0)
        {
            return false;
        }

        product.StockQuantity += quantity;
        return true;
    }

    public bool RemoveStock(int productId, int quantity)
    {
        Product? product = GetProductById(productId);

        if (product is null || quantity <= 0)
        {
            return false;
        }

        if (product.StockQuantity < quantity)
        {
            return false;
        }

        product.StockQuantity -= quantity;
        return true;
    }
}