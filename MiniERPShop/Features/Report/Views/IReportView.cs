using MiniERPShop.Features.Report.DTOs;

namespace MiniERPShop.Features.Report.Views;

public interface IReportView
{
    void ShowReport(ReportSummaryDto report);

    void ShowMessage(string message);
}

