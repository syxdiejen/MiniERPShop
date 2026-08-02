using MiniERPShop.Features.Inventory.Models;
using MiniERPShop.Features.Inventory.Services;
using MiniERPShop.Features.Inventory.Views;
using MiniERPShop.Game;

namespace MiniERPShop.Features.Inventory.Presenters;

public class InventoryPresenter
{
    private readonly IInventoryView _view;
    private readonly InventoryService _inventoryService;
    private readonly GameState _gameState;

    public InventoryPresenter(
        IInventoryView view,
        InventoryService inventoryService,
        GameState gameState)
    {
        _view = view;
        _inventoryService = inventoryService;
        _gameState = gameState;
    }

    public void DisplayInventory()
    {
        IReadOnlyList<Product> products =
            _inventoryService.GetAllProducts();

        _view.ShowProducts(products);
    }

    public void PurchaseStock()
    {
        DisplayInventory();

        int productId = _view.AskProductId();
        int quantity = _view.AskQuantity();

        Product? product =
            _inventoryService.GetProductById(productId);

        if (product is null)
        {
            _view.ShowError("Khong tim thay san pham.");
            return;
        }

        decimal totalCost =
            product.PurchasePrice * quantity;

        if (_gameState.Cash < totalCost)
        {
            _view.ShowError("Khong du tien de nhap hang.");
            return;
        }

        bool result =
            _inventoryService.AddStock(productId, quantity);

        if (!result)
        {
            _view.ShowError("Nhap hang that bai.");
            return;
        }

        _gameState.Cash -= totalCost;

        _view.ShowMessage(
            $"Nhap thanh cong {quantity} {product.Name}."
        );

        _view.ShowMessage(
            $"Tong chi phi: {totalCost:N0} VND."
        );

        _view.ShowMessage(
            $"Tien con lai: {_gameState.Cash:N0} VND."
        );
    }
}