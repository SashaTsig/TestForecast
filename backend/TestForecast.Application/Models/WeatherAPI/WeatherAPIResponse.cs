using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Models.WeatherAPI
{
    public class WeatherAPIResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }


        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
