using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;

namespace weather.Test;

public class TestWeatherForecast : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TestWeatherForecast(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory(DisplayName = "WeatherForecast deve responder com status 200 ~ 299 para rotas")]
    [InlineData("/weatherforecast")]
    public async Task GetEndpoint(string url)
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
    }
}