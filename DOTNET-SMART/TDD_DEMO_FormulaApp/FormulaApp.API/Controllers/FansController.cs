namespace FormulaApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FansController : ControllerBase
{
    [HttpGet(Name = "GetFans")]
    public async Task<IActionResult> GetFans()
    {
        var fans = new[]
        {
            new { Id = 1, Name = "Alice", FavoriteDriver = "Driver A" },
            new { Id = 2, Name = "Bob", FavoriteDriver = "Driver B" },
            new { Id = 3, Name = "Charlie", FavoriteDriver = "Driver C" }
        };

        return await Task.FromResult(Ok(fans));
    }
}