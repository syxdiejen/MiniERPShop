namespace MiniERPShop.Features.Sales.Views;

/// <summary>
/// Giao diện Console cho chức năng bán hàng.
/// </summary>
public class ConsoleSalesView : ISalesView
{
    /// <summary>
    /// Nhập ID sản phẩm.
    /// </summary>
    public int AskProductId()
    {
        while (true)
        {
            Console.Write("Nhap ID san pham: ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int productId)
                && productId > 0)
            {
                return productId;
            }

            ShowError("ID san pham phai là so nguyen duong.");
        }
    }

    /// <summary>
    /// Nhập số lượng bán.
    /// </summary>
    public int AskQuantity()
    {
        while (true)
        {
            Console.Write("Nhap so luong ban: ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int quantity)
                && quantity > 0)
            {
                return quantity;
            }

            ShowError("So luong phai lon hon 0.");
        }
    }

    /// <summary>
    /// Hiển thị thông báo thành công.
    /// </summary>
    public void ShowSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine();
        Console.WriteLine(message);

        Console.ResetColor();
    }

    /// <summary>
    /// Hiển thị thông báo lỗi.
    /// </summary>
    public void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine();
        Console.WriteLine(message);

        Console.ResetColor();
    }
}