using Microsoft.AspNetCore.Mvc;

namespace OrderCreationWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "CreateNewOrder")]
    public async Task<IActionResult> CreateNewOrder()
    {
        var createdOrder = new
        {
            ProductId = 31313,
            ProductName = "Order 1",
            UserEmail = "precupeduard99@gmail.com"
        };

        _logger.LogInformation($"New Order Has been created. Order ID: {createdOrder.ProductId}");
        return Ok(createdOrder);
    }
}
