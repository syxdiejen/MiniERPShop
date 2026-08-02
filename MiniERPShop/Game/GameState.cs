namespace MiniERPShop.Game;

public class GameState
{
    public int CurrentDay { get; set; } = 1;

    public decimal Cash { get; set; } = 500_000;

    public int CustomerSatisfaction { get; set; } = 100;

    public DailyReport Today { get; } = new();
    
    public void NextDay()
    {
        CurrentDay++;
        Today.Reset();
    }
}