using MiniERPShop.Models;
using MiniERPShop.Presenters;
using MiniERPShop.Services;
using MiniERPShop.Views;

List<Product> products =
[
    new Product
    {
        Id = 1,
        Code = "SP001",
        Name = "Nuoc ngot",
        PurchasePrice = 7_000,
        SalePrice = 10_000,
        StockQuantity = 10,
        MinimumStock = 5
    },
    new Product
    {
        Id = 2,
        Code = "SP002",
        Name = "Banh snack",
        PurchasePrice = 5_000,
        SalePrice = 8_000,
        StockQuantity = 10,
        MinimumStock = 5
    },
    new Product
    {
        Id = 3,
        Code = "SP003",
        Name = "Ca phe lon",
        PurchasePrice = 8_000,
        SalePrice = 12_000,
        StockQuantity = 10,
        MinimumStock = 5
    }
];

GameState gameState = new();

InventoryService inventoryService =
    new(products);

IInventoryView inventoryView =
    new ConsoleInventoryView();

InventoryPresenter inventoryPresenter =
    new(
        inventoryView,
        inventoryService,
        gameState
    );

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== MINI ERP SHOP =====");
    Console.WriteLine($"Ngay: {gameState.CurrentDay}");
    Console.WriteLine($"Tien mat: {gameState.Cash:N0} VND");
    Console.WriteLine();
    Console.WriteLine("1. Xem kho");
    Console.WriteLine("2. Nhap hang");
    Console.WriteLine("0. Thoat");
    Console.Write("Lua chon: ");

    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            inventoryPresenter.DisplayInventory();
            break;

        case "2":
            inventoryPresenter.PurchaseStock();
            break;

        case "0":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Lua chon khong hop le.");
            break;
    }
}