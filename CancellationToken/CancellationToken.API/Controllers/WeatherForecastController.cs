using CancellationToken.Shared.DTOs;
using CancellationToken.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CancellationToken.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase, IWeatherForecastExchange
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<WeatherForecastDTO>> GetAll(DateTime startDate)
        {
            try
            {
                await Task.Delay(1000);
                return Enumerable.Range(1, 5).Select(index => new WeatherForecastDTO
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
