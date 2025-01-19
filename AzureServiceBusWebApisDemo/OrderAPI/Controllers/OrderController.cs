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

    [HttpPost(Name = "SendOrderToEmail")]
    public async Task<IActionResult> SendOrderToEmail()
    {
        var createdOrder = new Order
        {
            OrderId = Guid.NewGuid(),
            OrderName = "Order Random Name"
        };

        await _serviceBusQueue.SendMessage("emailorderqueue", JsonConvert.SerializeObject(createdOrder));

        Console.WriteLine("--------------------------");
        _logger.LogInformation("Send order to email queue.");
        Console.WriteLine("Send order to email queue.");
        Console.WriteLine("Send order to email queue.");
        Console.WriteLine("--------------------------");
        return Ok(createdOrder);
    }
}
