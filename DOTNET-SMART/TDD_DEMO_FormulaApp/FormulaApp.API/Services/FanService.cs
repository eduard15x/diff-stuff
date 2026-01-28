using FormulaApp.API.Models;
using FormulaApp.API.Configuration;
using FormulaApp.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace FormulaApp.API.Services;

public class FanService : IFanService
{
    private readonly HttpClient _httpClient;
    private readonly ApiServiceConfig _config;

    public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
    {
        _httpClient = httpClient;
        _config = config.Value;
    }

    public async Task<List<Fan>?> GetAllFans()
    {
        var response = await _httpClient.GetAsync($"{_config.URL}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return new List<Fan>();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return new List<Fan>();
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            return null;
        }

        var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();

        return fans;
    }
}