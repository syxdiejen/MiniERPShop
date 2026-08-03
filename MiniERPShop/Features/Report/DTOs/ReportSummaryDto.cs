namespace MiniERPShop.Features.Report.DTOs
{
    public class ReportSummaryDto
    {
        public int CurrentDay { get; init; }
        public decimal Cash { get; init; }
        public decimal Revenue { get; init; }
        public decimal PurchaseAmount { get; init; }
        public decimal CostOfGoodsSold { get; init; }
        public decimal Profit { get; init; }
        public int SuccessfulOrders { get; init; }
        public int FailedOrders { get; init; }

    }
}
