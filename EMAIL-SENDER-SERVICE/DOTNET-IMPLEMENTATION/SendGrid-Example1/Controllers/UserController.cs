using Microsoft.AspNetCore.Mvc;
using SendGrid_Example1.Services;

namespace SendGrid_Example1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IEmailSender _emailSender;

    public UserController(ILogger<UserController> logger, IEmailSender emailSender)
    {
        _logger = logger;
        _emailSender = emailSender;
    }

    [HttpPost("create-user", Name = "GetWeatherForecast")]
    public async Task<IActionResult> CreateUser()
    {
        var user = new
        {
            UserName = "Eduard Precup",
            UserEmail = "p_eduard99@yahoo.com"
        };
        _logger.LogInformation($"User was created.");

        var emailSubject = "Account Created - Devuard Community";
        var emailReceiverMail = user.UserEmail;
        var emailReceiverUsername = user.UserName;
        var emailMessage = "We are happy to have you in our community. We hope our content will help you accelerate you skills in your career!";

        await _emailSender.SendEmail(emailSubject, emailReceiverMail, emailReceiverUsername, emailMessage);
        _logger.LogInformation($"Email was sent.");

        return Ok("User created");
    }
}
