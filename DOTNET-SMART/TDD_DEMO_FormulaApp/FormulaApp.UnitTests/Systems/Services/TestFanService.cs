using FluentAssertions;
using FormulaApp.API.Configuration;
using FormulaApp.API.Models;
using FormulaApp.API.Services;
using FormulaApp.UnitTests.Fixtures;
using FormulaApp.UnitTests.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace FormulaApp.UnitTests.Systems.Services;

public class TestFanService
{
    [Fact]
    // Test methods for FanService would go here
    public async Task GetAllFans_OnInvoked_HttpGet()
    {
        // Act
        var URL = "https://example.com/api/v1/fans";
        var response = FansFixtures.GetFans();
        var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
        var httpClient = new HttpClient(mockHandler.Object);
        var config = Options.Create(new ApiServiceConfig
        {
            URL = URL
        });

        var fanService = new FanService(httpClient, config);

        // Act
        await fanService.GetAllFans();

        // Assert
        mockHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(
                r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == URL
            ),
            ItExpr.IsAny<CancellationToken>()
        );
    }

    [Fact]
    public async Task GetAllFans_OnInvoked_ListOfFans()
    {
        // Act
        var URL = "https://example.com/api/v1/fans";
        var response = FansFixtures.GetFans();
        var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
        var httpClient = new HttpClient(mockHandler.Object);
        var config = Options.Create(new ApiServiceConfig
        {
            URL = URL
        });

        var fanService = new FanService(httpClient, config);

        // Act
        var result = await fanService.GetAllFans();

        // Assert
        result.Should().BeOfType<List<Fan>>();
    }

    [Fact]
    public async Task GetAllFans_OnInvoked_ReturnEmptyList()
    {
        // Act
        var URL = "https://example.com/api/v1/fans";
        var mockHandler = MockHttpHandler<Fan>.SetupReturnNotFound();
        var httpClient = new HttpClient(mockHandler.Object);
        var config = Options.Create(new ApiServiceConfig
        {
            URL = URL
        });

        var fanService = new FanService(httpClient, config);

        // Act
        var result = await fanService.GetAllFans();

        // Assert
        result.Count.Should().Be(0);
    }
}