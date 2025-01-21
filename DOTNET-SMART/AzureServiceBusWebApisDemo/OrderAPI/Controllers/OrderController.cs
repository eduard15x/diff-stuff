using AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus;
using AzureServiceBusWebApisDemo.ServiceBusDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrderAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{

    private readonly IServiceBusQueue _serviceBusQueue;
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger, IServiceBusQueue serviceBusQueue)
    {
        _logger = logger;
        _serviceBusQueue = serviceBusQueue;
    }

    [HttpPost("send-single-order-to-email", Name = "SendOrderToEmail")]
    public async Task<IActionResult> SendOrderToEmail()
    {
        var createdOrder = new Order
        {
            OrderId = Guid.NewGuid(),
            OrderName = "Order Random Name"
        };

        await _serviceBusQueue.SendMessage("emailorderqueue", createdOrder);

        Console.WriteLine("--------------------------");
        _logger.LogInformation("Send order to email queue.");
        Console.WriteLine("Send order to email queue.");
        Console.WriteLine("--------------------------");
        return Ok(createdOrder);
    }

    [HttpPost("send-batch-of-orders-to-email", Name = "SendBatchOfOrdersToEmail")]
    public async Task<IActionResult> SendBatchOfOrdersToEmail()
    {
        List<Order> createdOrderList = new List<Order>()
        {
            new() { OrderId = Guid.NewGuid(), OrderName = "First Order" },
            new() { OrderId = Guid.NewGuid(), OrderName = "Second Order" },
            new() { OrderId = Guid.NewGuid(), OrderName = "Third Order" },
            new() { OrderId = Guid.NewGuid(), OrderName = "Fourth Order" },
        };

        Console.WriteLine("-------------------------");
        _logger.LogInformation("Send list of orders to email queue.");
        Console.WriteLine("Send list of orders to email queue.");
        Console.WriteLine("-------------------------");

        await _serviceBusQueue.SendMessages("emailorderqueue", createdOrderList);

        return Ok(createdOrderList);
    }
}
