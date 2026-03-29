using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Models.WeatherAPI
{
    public class ForecastDay
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("hour")]
        public IEnumerable<HourData> Hours { get; set; }
    }
}
