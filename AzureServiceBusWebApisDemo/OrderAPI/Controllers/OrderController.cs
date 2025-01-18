using AzureServiceBusWebApisDemo.ServiceBusDelivery.AzureServiceBus;
using Microsoft.AspNetCore.Mvc;

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

        DateTime sendingTimeMessage = DateTime.UtcNow;

        var createdOrder = new
        {
            OrderId = 1231,
            OrderName = "Nike Shoes",
            OrderEmailAssigned = $"precupeduard99@gmai.com, {sendingTimeMessage}"
        };

        await _serviceBusQueue.SendMessage("emailorderqueue", createdOrder.OrderEmailAssigned);

        _logger.LogInformation("Send order to email queue.");
        Console.WriteLine("Send order to email queue.");
        return Ok(createdOrder);
    }
}
