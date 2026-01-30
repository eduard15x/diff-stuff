using Microsoft.EntityFrameworkCore;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Models;
using OrdersAPI.Queries;

namespace OrdersAPI.Handlers;

public class GetOrdersSummaryQueryHandler : IQueryHandler<GetOrdersSummaryQuery, List<OrderSummaryDto>?>
{
    private readonly AppDbContext _dbContext;

    public GetOrdersSummaryQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public static async Task<Order?> Handle(GetOrderByIdQuery query, AppDbContext dbContext)
    // {
    // }

    public async Task<List<OrderSummaryDto>?> HandleAsync(GetOrdersSummaryQuery query)
    {
        var orders = await _dbContext.Orders
            .Select(o => new OrderSummaryDto
            {
                Id = o.Id,
                CustomerFullName = $"{o.FirstName} {o.LastName}",
                Status = o.Status,
                TotalCost = o.TotalCost
            })
            .ToListAsync();

        if (orders.Count == 0)
        {
            return new List<OrderSummaryDto>();
        }

        return orders;
    }
}