public class SalesOrder
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = "";

    public List<OrderItem> Items { get; set; } = new();

    public decimal Total =>
        Items.Sum(i => i.Total);

    public decimal Cost =>
        Items.Sum(i => i.Cost);
}