namespace MiniERPShop.Game;

public class DailyReport
{
    public decimal Revenue { get; set; }
    public decimal Cost { get; set; }
    public decimal Profit => Revenue - Cost;
    public int SuccessfulOrders { get; set; } 
    public int FailedOrders { get; set; }
    public void Reset()
    {
        Revenue = 0;
        Cost = 0;
        SuccessfulOrders = 0;
        FailedOrders = 0;
    }
}