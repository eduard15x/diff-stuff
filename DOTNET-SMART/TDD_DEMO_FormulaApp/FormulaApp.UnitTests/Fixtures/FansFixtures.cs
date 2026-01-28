using FormulaApp.API.Models;

namespace FormulaApp.UnitTests.Fixtures;

public static class FansFixtures
{
    public static new List<Fan> GetFans() => new()
    {
        new Fan() { Id = 2, Name = "Mike Doe", Email = "mike.doe@example.com" },
        new Fan() { Id = 1, Name = "John Doe", Email = "john.doe@example.com" }
    };
}