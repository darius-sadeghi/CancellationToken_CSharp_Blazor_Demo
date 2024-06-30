using CancellationToken.Shared.DTOs;
using CancellationToken.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CancellationToken.Shared.Proxies
{
    public class WeatherForecastProxy : IWeatherForecastExchange
    {
        private HttpClient httpClient { get; set; }
        public WeatherForecastProxy(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<WeatherForecastDTO>> GetAll(DateTime startDate)
        {
            try
            {
                var result = await httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("/api/WeatherForecast");
                if (result != null)
                {
                    return result;
                }
                return new List<WeatherForecastDTO>();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}
