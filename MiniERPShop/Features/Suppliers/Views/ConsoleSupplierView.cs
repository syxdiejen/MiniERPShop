using MiniERPShop.Features.Suppliers.Models;

namespace MiniERPShop.Features.Suppliers.Views;

public class ConsoleSupplierView : ISupplierView
{
    public void ShowSuppliers(IReadOnlyList<Supplier> suppliers)
    {
        Console.WriteLine();
        Console.WriteLine("===== DANH SÁCH NHÀ CUNG CẤP =====");

        foreach (Supplier supplier in suppliers)
        {
            Console.WriteLine(
                $"{supplier.Id,-3}" +
                $"{supplier.Code,-10}" +
                $"{supplier.Name,-25}" +
                $"{supplier.Phone}");
        }

        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}