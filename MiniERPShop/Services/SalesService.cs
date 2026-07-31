using MiniERPShop.Models;
using MiniERPShop.Services;

public class SalesService
{
    private readonly InventoryService _inventory;

    private readonly GameState _gameState;

    public SalesService(
        InventoryService inventory,
        GameState gameState)
    {
        _inventory = inventory;
        _gameState = gameState;
    }

    public bool Sell(int productId, int quantity) 
    { 
        
    }
}