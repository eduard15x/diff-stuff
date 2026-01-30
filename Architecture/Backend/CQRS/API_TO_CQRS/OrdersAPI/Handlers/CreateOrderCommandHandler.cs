using FluentValidation;
using OrdersAPI.Commands;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Events;
using OrdersAPI.Models;

namespace OrdersAPI.Handlers;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
{
    private readonly WriteDbContext _dbContext;
    private readonly IValidator<CreateOrderCommand> _validator;
    private readonly IEventPublisher _eventPublisher;

    public CreateOrderCommandHandler(WriteDbContext dbContext, IValidator<CreateOrderCommand> validator, IEventPublisher eventPublisher)
    {
        _dbContext = dbContext;
        _validator = validator;
        _eventPublisher = eventPublisher;
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
        var validationResult = await _validator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

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

        var orderCreatedEvent = new OrderCreatedEvent
        {
            OrderId = order.Id,
            CustomerName = $"{order.FirstName} {order.LastName}",
            TotalCost = order.TotalCost
        };
        await _eventPublisher.PublishAsync(orderCreatedEvent);

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