using MiniERPShop.DTOs;

namespace MiniERPShop.Features.Report.Views;
public class ConsoleReportView : IReportView
{
    public void ShowReport(ReportSummaryDto report)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("=========================================");
        Console.WriteLine("           BÁO CÁO HÔM NAY");
        Console.WriteLine("=========================================");

        Console.ResetColor();

        Console.WriteLine($"Ngay                : {report.CurrentDay}");
        Console.WriteLine($"Tien mat            : {report.Cash:N0} VND");

        Console.WriteLine("-----------------------------------------");

        Console.WriteLine($"Doanh thu           : {report.Revenue:N0} VND");
        Console.WriteLine($"Gia von             : {report.Cost:N0} VND");
        Console.WriteLine($"Loi nhuan           : {report.Profit:N0} VND");

        Console.WriteLine("-----------------------------------------");

        Console.WriteLine($"Don thanh cong      : {report.SuccessfulOrders}");
        Console.WriteLine($"Don that bai        : {report.FailedOrders}");

        Console.WriteLine("=========================================");
        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

