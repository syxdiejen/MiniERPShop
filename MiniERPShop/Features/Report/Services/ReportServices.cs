using MiniERPShop.DTOs;
using MiniERPShop.Game;

namespace MiniERPShop.Features.Report.Services;

public class ReportServices
{
    private readonly GameState _gameState;

    public ReportServices(GameState gameState)
    {
        _gameState = gameState;
    }

    public DailyReport GetTodayReport()
    {
        return _gameState.Today;
    }

    public ReportSummaryDto GetTodaySummary()
    {
        return new ReportSummaryDto
        {
            CurrentDay = _gameState.CurrentDay,
            Cash = _gameState.Cash,
            Revenue = _gameState.Today.Revenue,
            Cost = _gameState.Today.Cost,
            Profit = _gameState.Today.Profit,
            SuccessfulOrders = _gameState.Today.SuccessfulOrders,
            FailedOrders = _gameState.Today.FailedOrders
        };
    }

    public void NextDay()
    {
        _gameState.NextDay();
    }
}
