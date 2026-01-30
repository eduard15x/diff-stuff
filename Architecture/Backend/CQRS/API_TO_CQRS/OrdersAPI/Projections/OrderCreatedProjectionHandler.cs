using OrdersAPI.Data;
using OrdersAPI.Events;
using OrdersAPI.Models;

namespace OrdersAPI.Projections;

public class OrderCreatedProjectionHandler : IEventHandler<OrderCreatedEvent>
{
    private readonly ReadDbContext _readDbContext;
    public OrderCreatedProjectionHandler(ReadDbContext readDbContext)
    {
        _readDbContext = readDbContext;
    }

    public async Task HandleAsync(OrderCreatedEvent evt)
    {
        var newSyncOrder = new Order
        {
            Id = evt.OrderId,
            FirstName = evt.CustomerName,
            LastName = "LastName not mapped in dto",
            Status = "Created",
            CreatedAt = DateTime.Now,
            TotalCost = evt.TotalCost
        };

        await _readDbContext.Orders.AddAsync(newSyncOrder);
        await _readDbContext.SaveChangesAsync();
    }
}