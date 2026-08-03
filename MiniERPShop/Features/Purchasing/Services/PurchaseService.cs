using MiniERPShop.Features.Inventory.Models;
using MiniERPShop.Features.Inventory.Services;
using MiniERPShop.Features.Purchasing.DTOs;
using MiniERPShop.Features.Purchasing.Models;
using MiniERPShop.Game;

namespace MiniERPShop.Features.Purchasing.Services
{
    public class PurchaseService
    {
        private readonly InventoryService _inventoryService;
        private readonly GameState _gameState;

        private readonly List<PurchaseOrder> _purchaseOrders = [];

        public PurchaseService (InventoryService inventoryService, GameState gameState)
        {
            _inventoryService = inventoryService;
            _gameState = gameState;
        }

        public IReadOnlyList<PurchaseOrder> GetPurchaseOrders()
        { return _purchaseOrders.AsReadOnly(); }

        public PurchaseResultDto PurchaseProduct(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new PurchaseResultDto
                {
                    Success = false,
                    Message = "Quantity must be greater than zero.",
                    TotalCost = 0
                };
            }

            Product? product = _inventoryService.GetProductById(productId);

            if (product == null)
            {
                return new PurchaseResultDto
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            decimal totalCost = product.PurchasePrice * quantity;

            if (_gameState.Cash < totalCost)
            {
                return new PurchaseResultDto
                {
                    Success = false,
                    Message = "Insufficient funds."
                };
            }

            bool success = _inventoryService.AddStock(productId, quantity);

            if (!success)
            {
                return new PurchaseResultDto
                {
                    Success = false,
                    Message = "Failed to add stock."
                };
            }

            _gameState.Cash -= totalCost;

            _gameState.Today.PurchaseAmount += totalCost;

            _purchaseOrders.Add(new PurchaseOrder 
            {
                ProductId = productId,
                ProductCode = product.Code,
                ProductName = product.Name,
                Quantity = quantity,
                UnitPrice = product.PurchasePrice
            });

            return new PurchaseResultDto
            {
                Success = true,
                Message = "Purchase successful.",
                TotalCost = totalCost
            };
        }
    }
}
