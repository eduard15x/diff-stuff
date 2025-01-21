using Microsoft.AspNetCore.Mvc;
using SMTP_Example2.Models;
using SMTP_Example2.Services;

namespace SMTP_Example2.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IEmailSender _emailSender;

    public OrderController(ILogger<OrderController> logger, IEmailSender emailSender)
    {
        _logger = logger;
        _emailSender = emailSender;
    }

    [HttpGet("/create", Name = "CreateOrder")]
    public async Task<IActionResult> CreateOrder()
    {
        var currentUserInformation = new
        {
            UserName = "Eduard Precup",
            UserEmail = "precupeduard99@gmail.com",
            UserEmailSecond = "p_eduard99@yahoo.com"
        };

        await _emailSender.SendEmail(currentUserInformation.UserEmail, "SMTP Email Web API", "This is the body of email");
        _logger.LogInformation("Send first email");


        return Ok("Order created");
    }
}
