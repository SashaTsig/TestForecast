using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForecast.Application.Dto;

namespace TestForecast.Application.Services.Interfaces
{
    public interface IForecastService
    {
        ForecastDto GetForecast(double lat, double lon);
    }
}
