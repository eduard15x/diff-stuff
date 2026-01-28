using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FansController : ControllerBase
{
    [HttpGet(Name = "GetFans")]
    public async Task<IActionResult> GetFans()
    {
        // Simulate fetching fan data
        // var fans = new[]
        // {
        //     new { Id = 1, Name = "Fan A", Team = "Team X" },
        //     new { Id = 2, Name = "Fan B", Team = "Team Y" }
        // };

        return Ok("fans");
    }
}