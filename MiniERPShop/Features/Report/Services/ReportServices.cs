using MiniERPShop.Features.Report.DTOs;
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
            PurchaseAmount = _gameState.Today.PurchaseAmount,
            CostOfGoodsSold = _gameState.Today.CostOfGoodsSold,
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
