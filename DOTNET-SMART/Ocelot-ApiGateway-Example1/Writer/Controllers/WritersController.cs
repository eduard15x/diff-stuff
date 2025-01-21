using Microsoft.AspNetCore.Mvc;

namespace Writer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WritersController : ControllerBase
{
    private readonly ILogger<WritersController> _logger;

    public WritersController(ILogger<WritersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWriters")]
    public async Task<IActionResult> GetWriters()
    {
        await Task.CompletedTask;

        _logger.LogInformation("Block thread for 3 seconds in timeout.");
        await Task.Delay(3000);
        _logger.LogInformation("Release the thread after timeout expired.");

        return Ok("get writers");
    }

    [HttpGet("/{id}", Name = "GetSingleWriter")]
    public async Task<IActionResult> GetSingleWriter([FromRoute] int id)
    {
        await Task.CompletedTask;
        return Ok($"get writer with id {id}");
    }
}
