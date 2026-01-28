using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApp.UnitTests.Systems.Controllers;


// METHOD_CONDITION_RETURN-RESPONSE

// Arrange - setup my task, what need to use, additional data etc (requirements, dependencies)
// Act - executing the method
// Assert - verify the result

public class TestFansController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var fansController = new FansController();
        // Act

        var result = (OkObjectResult)await fansController.GetFans();
        // we manually cast (convert) the result to OkObjectResult type

        // Assert
        result.StatusCode.Should().Be(200);
        // Assert.Equal(200, result.StatusCode);
    }
}