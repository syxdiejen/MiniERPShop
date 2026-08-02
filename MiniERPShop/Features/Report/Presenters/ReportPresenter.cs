using MiniERPShop.DTOs;
using MiniERPShop.Features.Report.Services;
using MiniERPShop.Features.Report.Views;

namespace MiniERPShop.Features.Report.Presenters;

public class ReportPresenter
{
    private readonly IReportView _view;
    private readonly ReportServices _reportServices;

    public ReportPresenter(
        IReportView view,
        ReportServices reportServices)
    {
        _view = view;
        _reportServices = reportServices;
    }

    public void ShowTodayReport()
    {
        ReportSummaryDto report = _reportServices.GetTodaySummary();
        _view.ShowReport(report);
    }

    public void NextDay()
    {
        _reportServices.NextDay();
        
        _view.ShowMessage("Đã chuyển sang ngày mới. Báo cáo hôm nay đã được reset.");
    }
}
