namespace OrdersAPI.Dtos;

public class OrderSummaryDto
{
    public int Id { get; set; }
    public string CustomerFullName { get; set; }
    public string Status { get; set; }
    public decimal TotalCost { get; set; }
}