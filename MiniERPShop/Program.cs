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
using MiniERPShop.Features.Purchasing.Presenters;
using MiniERPShop.Features.Purchasing.Services;
using MiniERPShop.Features.Purchasing.Views;
using MiniERPShop.Features.Suppliers.Models;
using MiniERPShop.Features.Suppliers.Services;
using MiniERPShop.Features.Suppliers.Views;
using MiniERPShop.Features.Suppliers.Presenters;

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

List<Supplier> suppliers =
[
    new Supplier
    {
        Id = 1,
        Code = "NCC001",
        Name = "Coca Viet Nam",
        Phone = "0900000001",
        Address = "Ha Noi"
    },

    new Supplier
    {
        Id = 2,
        Code = "NCC002",
        Name = "Acecook",
        Phone = "0900000002",
        Address = "Ho Chi Minh"
    },

    new Supplier
    {
        Id = 3,
        Code = "NCC003",
        Name = "Vinamilk",
        Phone = "0900000003",
        Address = "Da Nang"
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

SupplierService supplierService =
    new(suppliers);

ISupplierView supplierView =
    new ConsoleSupplierView();

SupplierPresenter supplierPresenter =
    new(
        supplierView,
        supplierService);

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
    Console.WriteLine("2. Xem nha cung cap");
    Console.WriteLine("3. Nhap hang");
    Console.WriteLine("4. Bán hàng");
    Console.WriteLine("5. Báo cáo");
    Console.WriteLine("6. Sang ngày mới");
    Console.WriteLine("0. Thoat");
    Console.Write("Lua chon: ");

    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            inventoryPresenter.DisplayInventory();
            break;

        case "2":
            supplierPresenter.DisplaySuppliers();
            break;


        case "3":
            purchasePresenter.PurchaseProduct();
            break;


        case "4":
            salesPresenter.SellProduct();
            break;


        case "5":
            reportPresenter.ShowTodayReport();
            break;


        case "6":
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