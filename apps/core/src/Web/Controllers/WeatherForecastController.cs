using AudioStreaming.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using AudioStreaming.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Web.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
