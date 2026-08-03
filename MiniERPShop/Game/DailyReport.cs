namespace MiniERPShop.Game;

public class DailyReport
{
    public decimal Revenue { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal CostOfGoodsSold { get; set; }
    public decimal Profit => Revenue - CostOfGoodsSold;
    public int SuccessfulOrders { get; set; } 
    public int FailedOrders { get; set; }
    public void Reset()
    {
        Revenue = 0;
        PurchaseAmount = 0;
        CostOfGoodsSold = 0;
        SuccessfulOrders = 0;
        FailedOrders = 0;
    }
}