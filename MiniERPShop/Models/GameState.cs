namespace MiniERPShop.Models;

public class GameState
{
    public int CurrentDay { get; set; } = 1;

    public decimal Cash { get; set; } = 500_000;

    public int CustomerSatisfaction { get; set; } = 100;

    public decimal RevenueToday { get; set; }

    public decimal CostToday { get; set; }

    public int SuccessfulOrders { get; set; }

    public int FailedOrders { get; set; }

    public decimal ProfitToday =>
        RevenueToday - CostToday;

    public void ResetDailyStatistics()
    {
        RevenueToday = 0;
        CostToday = 0;
        SuccessfulOrders = 0;
        FailedOrders = 0;
    }
}