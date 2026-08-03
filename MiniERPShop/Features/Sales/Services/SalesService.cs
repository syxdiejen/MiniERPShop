using MiniERPShop.Common.Results;
using MiniERPShop.Features.Inventory.Models;
using MiniERPShop.Features.Inventory.Services;
using MiniERPShop.Game;

namespace MiniERPShop.Features.Sales.Services;
public class SalesService
{
    private readonly InventoryService _inventoryService;
    private readonly GameState _gameState;

    public SalesService(
        InventoryService inventoryService,
        GameState gameState)
    {
        _inventoryService = inventoryService;
        _gameState = gameState;
    }

    public OperationResult Sell(
        int productId,
        int quantity)
    {
        if (quantity <= 0)
        {
            _gameState.Today.FailedOrders++;

            return OperationResult.Fail(
                "Số lượng phải lớn hơn 0.");
        }

        Product? product =
            _inventoryService.GetProductById(productId);

        if (product is null)
        {
            _gameState.Today.FailedOrders++;

            return OperationResult.Fail(
                "Không tìm thấy sản phẩm.");
        }

        if (!product.HasEnoughStock(quantity))
        {
            _gameState.Today.FailedOrders++;

            return OperationResult.Fail(
                "Không đủ tồn kho.");
        }

        bool removed =
            _inventoryService.RemoveStock(
                productId,
                quantity);

        if (!removed)
        {
            _gameState.Today.FailedOrders++;

            return OperationResult.Fail(
                "Xuất kho thất bại.");
        }

        decimal revenue =
            product.SalePrice * quantity;

        decimal cost =
            product.PurchasePrice * quantity;

        _gameState.Cash += revenue;
        _gameState.Today.Revenue += revenue;
        _gameState.Today.CostOfGoodsSold += cost;
        _gameState.Today.SuccessfulOrders++;

        return OperationResult.Ok(
            $"Đã bán {quantity} {product.Name}.");
    }
}