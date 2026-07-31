using MiniERPShop.Models;

namespace MiniERPShop.Views;

public class ConsoleInventoryView : IInventoryView
{
    public void ShowProducts(IReadOnlyList<Product> products)
    {
        Console.WriteLine();
        Console.WriteLine("===== DANH SACH SAN PHAM =====");
        Console.WriteLine(
            "{0,-5} {1,-10} {2,-20} {3,12} {4,12} {5,10} {6,-12}",
            "ID",
            "Ma",
            "Ten",
            "Gia nhap",
            "Gia ban",
            "Ton kho",
            "Trang thai"
        );

        foreach (Product product in products)
        {
            string status = product.IsLowStock()
                ? "Sap het"
                : "Con hang";

            Console.WriteLine(
                "{0,-5} {1,-10} {2,-20} {3,12:N0} {4,12:N0} {5,10} {6,-12}",
                product.Id,
                product.Code,
                product.Name,
                product.PurchasePrice,
                product.SalePrice,
                product.StockQuantity,
                status
            );
        }

        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowError(string message)
    {
        Console.WriteLine($"Loi: {message}");
    }

    public int AskProductId()
    {
        while (true)
        {
            Console.Write("Nhap ID san pham: ");

            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                return productId;
            }

            ShowError("ID san pham phai la so nguyen.");
        }
    }

    public int AskQuantity()
    {
        while (true)
        {
            Console.Write("Nhap so luong: ");

            if (int.TryParse(Console.ReadLine(), out int quantity)
                && quantity > 0)
            {
                return quantity;
            }

            ShowError("So luong phai la so nguyen lon hon 0.");
        }
    }
}