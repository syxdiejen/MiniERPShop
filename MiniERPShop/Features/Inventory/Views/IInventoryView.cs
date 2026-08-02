using MiniERPShop.Features.Inventory.Models;

namespace MiniERPShop.Features.Inventory.Views;

public interface IInventoryView
{
    void ShowProducts(IReadOnlyList<Product> products);

    void ShowMessage(string message);

    void ShowError(string message);

    int AskProductId();

    int AskQuantity();
}