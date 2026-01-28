namespace FormulaApp.API.Controllers;

using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FansController : ControllerBase
{
    private readonly IFanService _fanService;

    public FansController(IFanService fanService)
    {
        _fanService = fanService;
    }

    [HttpGet(Name = "GetFans")]
    public async Task<IActionResult> GetFans()
    {
        // Simulate fetching fan data
        List<Fan> fans = await _fanService.GetAllFans();

        if (fans.Any())
        {
            return Ok(fans);
        }

        return NotFound();
    }
}