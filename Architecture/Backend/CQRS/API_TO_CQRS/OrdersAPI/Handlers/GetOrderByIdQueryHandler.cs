using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Models;
using OrdersAPI.Queries;

namespace OrdersAPI.Handlers;

public class GetOrderByIdQueryHandler: IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly AppDbContext _dbContext;

    public GetOrderByIdQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public static async Task<Order?> Handle(GetOrderByIdQuery query, AppDbContext dbContext)
    // {
    // }

    public async Task<OrderDto?> HandleAsync(GetOrderByIdQuery query)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == query.OrderId);
        if (order is null)
        {
            return null;
        }

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