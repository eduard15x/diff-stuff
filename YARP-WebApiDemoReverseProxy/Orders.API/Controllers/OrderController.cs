using Microsoft.AspNetCore.Mvc;

namespace Orders.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/create", Name = "CreateOrder")]
    public async Task<string> CreateNewOrder([FromQuery] int id, [FromQuery] int quantity) => $"Order with ID: {id} and QUANTITY: {quantity} created";

}
