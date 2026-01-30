namespace OrdersAPI.Controllers;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Commands;
using OrdersAPI.Data;
using OrdersAPI.Dtos;
using OrdersAPI.Handlers;
using OrdersAPI.Models;
using OrdersAPI.Queries;

[ApiController]
[Route("api/[controller]")]
public class OrderControllers : ControllerBase
{
    // private readonly AppDbContext _context;

    // public OrderControllers(AppDbContext context)
    // {
    //     _context = context;
    // }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetOrdersSummary(
        IQueryHandler<GetOrdersSummaryQuery, List<OrderSummaryDto>> handler
    )
    {
        // var orders = await GetOrdersSummaryQueryHandler.Handle(
        //     new GetOrdersSummaryQuery(),
        //     _context
        // );

        var orders = await handler.HandleAsync(new GetOrdersSummaryQuery());
        return Ok(orders);
    }

    [HttpGet]
    [Route("{id}", Name = "GetOrderById")]
    public async Task<IActionResult> GetOrderById(
        IQueryHandler<GetOrderByIdQuery, OrderDto> handler,
        int id
    )
    {
        // var order = await GetOrderByIdQueryHandler.Handle(
        //     new GetOrderByIdQuery(id),
        //     _context
        // );

        var order = await handler.HandleAsync(new GetOrderByIdQuery(id));
        if (order == null)
        {
            return NotFound("Order not found");
        }

        return Ok(order);
    }

    [HttpPost("create")]
    // public async Task<IActionResult> Create(CreateOrderCommand command)
    public async Task<IActionResult> Create(
        ICommandHandler<CreateOrderCommand, OrderDto> handler,
        CreateOrderCommand command
    )
    {
        // var createdOrder = await CreateOrderCommandHandler.Handle(
        //     command,
        //     _context
        // );
        try
        {

            var createdOrder = await handler.HandleAsync(command);
            if (createdOrder == null)
            {
                return BadRequest("Could not create order");
            }

            // _context.Orders.Add(order);
            // await _context.SaveChangesAsync();

            return Created($"/api/order{createdOrder.Id}", createdOrder);

            // return CreatedAtRoute("GetOrderById", new { id = order.Id }, order);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
            return BadRequest(new { Errors = errors });
        }
    }
}