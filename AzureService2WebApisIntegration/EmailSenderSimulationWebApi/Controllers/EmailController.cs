// using Microsoft.AspNetCore.Mvc;

// namespace EmailSenderSimulationWebApi.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class EmailController : ControllerBase
// {
//     private readonly ILogger<EmailController> _logger;

//     public EmailController(ILogger<EmailController> logger)
//     {
//         _logger = logger;
//     }

//     [HttpGet(Name = "SendNewEmail")]
//     public async Task CreateNewOrder()
//     {
//         var createdOrder = new
//         {
//             ProductId = 31313,
//             ProductName = "Order 1",
//             UserEmail = "precupeduard99@gmail.com"
//         };

//         _logger.LogInformation($"New Order Has been created. Order ID: {createdOrder.ProductId}");
//         Console.WriteLine("Email was sent.");
//     }
// }
