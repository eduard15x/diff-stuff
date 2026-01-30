using OrdersAPI.Commands;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Models;

namespace OrdersAPI.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
{
    private readonly AppDbContext _dbContext;

    public CreateOrderCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public static async Task<Order> Handle(CreateOrderCommand command, AppDbContext dbContext)
    // {
    //     var order = new Order
    //     {
    //         FirstName = command.FirstName,
    //         LastName = command.LastName,
    //         Status = command.Status,
    //         CreatedAt = DateTime.Now,
    //         TotalCost = command.TotalCost,
    //     };

    //     await dbContext.Orders.AddAsync(order);
    //     await dbContext.SaveChangesAsync();

    //     return order;
    // }

    public async Task<OrderDto> HandleAsync(CreateOrderCommand command)
    {

        var order = new Order
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Status = command.Status,
            CreatedAt = DateTime.Now,
            TotalCost = command.TotalCost,
        };

        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();

        return new OrderDto
        {
            Id = order.Id,
            FirstName = order.FirstName,
            LastName = order.LastName,
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            TotalCost = order.TotalCost
        };
    }
}