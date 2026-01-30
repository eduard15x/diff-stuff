public class OrderCreatedEvent
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public decimal TotalCost { get; set; }
}