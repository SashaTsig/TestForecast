using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForecast.Application.Services.Interfaces;

namespace TestForecast.Application.Services.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        private const string WEATHERAPI_BASE_URL_KEY = "WeatherAPIUrl";
        private const string WEATHERAPI_KEY_KEY = "WeatherAPIKey";
        private const string WEATHERAPI_DEFAULT_LAT = "Default_Latitude";
        private const string WEATHERAPI_DEFAULT_LON = "Default_Longitude";
        public string GetWeatherAPIBaseUrl()
        {
            return GetRequiredString(WEATHERAPI_BASE_URL_KEY);
        }

        public string GetWeatherAPIKey()
        {
            return GetRequiredString(WEATHERAPI_KEY_KEY);
        }

        public string GetWeatherAPIDefaultLat()
        {
            return GetRequiredString(WEATHERAPI_DEFAULT_LAT);
        }

        public string GetWeatherAPIDefaultLon()
        {
            return GetRequiredString(WEATHERAPI_DEFAULT_LON);
        }

        private string GetRequiredString(string key)
        {
            var result = ConfigurationManager.AppSettings[key];

            if (String.IsNullOrEmpty(result))
                throw new Exception($"Ключ {key} не найден в конфиге.");

            return result;
        }
    }
}
