using MiniERPShop.Features.Inventory.Models;
using MiniERPShop.Features.Inventory.Presenters;
using MiniERPShop.Features.Inventory.Services;
using MiniERPShop.Features.Inventory.Views;
using MiniERPShop.Features.Report.Presenters;
using MiniERPShop.Features.Report.Services;
using MiniERPShop.Features.Report.Views;
using MiniERPShop.Features.Sales.Presenters;
using MiniERPShop.Features.Sales.Services;
using MiniERPShop.Features.Sales.Views;
using MiniERPShop.Features.Purchasing.DTOs;
using MiniERPShop.Features.Purchasing.Models;
using MiniERPShop.Features.Purchasing.Presenters;
using MiniERPShop.Features.Purchasing.Services;
using MiniERPShop.Features.Purchasing.Views;

using MiniERPShop.Game;

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

InventoryService inventoryService = new(products);

IInventoryView inventoryView = new ConsoleInventoryView();

InventoryPresenter inventoryPresenter =
    new(
        inventoryView,
        inventoryService,
        gameState
    );

SalesService salesService =
    new(
        inventoryService,
        gameState);

ISalesView salesView =
    new ConsoleSalesView();

SalesPresenter salesPresenter =
    new(
        salesView,
        salesService);

ReportServices reportServices = new(gameState);

IReportView reportView = new ConsoleReportView();

ReportPresenter reportPresenter = new(
        reportView,
        reportServices);

PurchaseService purchaseService = new(inventoryService, gameState);

IPurchaseView purchaseView = new ConsolePurchaseView();

PurchasePresenter purchasePresenter = new(
    purchaseView,
    purchaseService);

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
    Console.WriteLine("3. Bán hàng");
    Console.WriteLine("4. Báo cáo");
    Console.WriteLine("5. Sang ngày mới");
    Console.WriteLine("0. Thoat");
    Console.Write("Lua chon: ");

    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            inventoryPresenter.DisplayInventory();
            break;

        case "2":
            purchasePresenter.PurchaseProduct();
            break;

        case "3":
            salesPresenter.SellProduct();
            break;

        case "4":
            reportPresenter.ShowTodayReport();
            break;

        case "5":
            reportServices.NextDay();
            break;

        case "0":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Lua chon khong hop le.");
            break;
    }
}