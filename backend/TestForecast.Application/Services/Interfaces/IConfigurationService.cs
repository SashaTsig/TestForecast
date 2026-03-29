using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Services.Interfaces
{
    public interface IConfigurationService
    {
        string GetWeatherAPIBaseUrl();

        string GetWeatherAPIKey();

        string GetWeatherAPIDefaultLat();

        string GetWeatherAPIDefaultLon();
  
    }
}
