using GenericBaseEntityInCleanArchitecture.Data;
using GenericBaseEntityInCleanArchitecture.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenericBaseEntityInCleanArchitecture.Controllers;

[ApiController]
[Route("/api/test")]
public class WeatherForecastController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }


    // Create a new specialization
    [HttpPost("/create-specialization")]
    public async Task<IActionResult> CreateSpecialization()
    {
        Specialization newlyCreatedSpecialization = new Specialization
        {
            Name = "Informatica",
            TotalYears = 3,
        };

        _dbContext.Specializations.Add(newlyCreatedSpecialization);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(newlyCreatedSpecialization.ExternalId.ToString());

        return Ok(newlyCreatedSpecialization);
    }


    // Create a new specialization
    [HttpPost("/create-specialization-year")]
    public async Task<IActionResult> CreateSpecializationYear()
    {
        SpecializationYear newlyCreatedSpecializationYear = new SpecializationYear
        {
            SpecializationId = 2,
            YearNumber = 2,
        };

        _dbContext.SpecializationYears.Add(newlyCreatedSpecializationYear);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(newlyCreatedSpecializationYear.ExternalId.ToString());

        return Ok(newlyCreatedSpecializationYear);
    }


    [HttpGet(Name = "GetData")]
    public async Task<IActionResult> GetData()
    {
        return Ok("test");
    }


    [HttpPost(Name = "PostData")]
    public async Task<IActionResult> PostData()
    {
        return Ok("test");
    }
}
