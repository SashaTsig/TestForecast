using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Models.WeatherAPI
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public IEnumerable<ForecastDay> Days { get; set; }
    }
}
