using FluentAssertions;
using FormulaApp.API.Controllers;
using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using FormulaApp.UnitTests.Fixtures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
        var mockFanService = new Mock<IFanService>();
        mockFanService
            .Setup(service => service.GetAllFans())
            .ReturnsAsync(FansFixtures.GetFans());

        var fansController = new FansController(mockFanService.Object);
        // Act
        // we manually cast (convert) the result to OkObjectResult type
        var result = (OkObjectResult)await fansController.GetFans();

        // Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokeService()
    {
        // Arrange
        var mockFanService = new Mock<IFanService>();
        mockFanService
            .Setup(service => service.GetAllFans())
            .ReturnsAsync(FansFixtures.GetFans());

        var fansController = new FansController(mockFanService.Object);

        // Act
        var result = (OkObjectResult)await fansController.GetFans();

        // Assert
        mockFanService.Verify(service => service.GetAllFans(), Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfFans()
    {
        // Arrange
        var mockFanService = new Mock<IFanService>();
        mockFanService
            .Setup(service => service.GetAllFans())
            .ReturnsAsync(FansFixtures.GetFans());

        var fansController = new FansController(mockFanService.Object);

        // Act
        var result = (OkObjectResult)await fansController.GetFans();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<List<Fan>>();
    }

    [Fact]
    public async Task Get_OnNoFansFound_ReturnNotFound()
    {
        // Arrange
        var mockFanService = new Mock<IFanService>();
        mockFanService
            .Setup(service => service.GetAllFans())
            .ReturnsAsync(new List<Fan>());

        var fansController = new FansController(mockFanService.Object);

        // Act
        var result = (NotFoundResult)await fansController.GetFans();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }
}