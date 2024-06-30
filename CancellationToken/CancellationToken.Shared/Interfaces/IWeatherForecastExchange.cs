using CancellationToken.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancellationToken.Shared.Interfaces
{
    public interface IWeatherForecastExchange
    {
        Task<List<WeatherForecastDTO>> GetAll(DateTime startDate);
    }
}
