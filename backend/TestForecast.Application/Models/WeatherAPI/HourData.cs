using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Models.WeatherAPI
{
    public struct HourData
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("temp_c")]
        public decimal Temperature { get; set; }

        [JsonProperty("wind_kph")]
        public decimal WindSpeed { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }

        [JsonProperty("will_it_rain")]
        public int IsRain { get; set; }

        [JsonProperty("will_it_snow")]
        public int IsSnow { get; set; }
    }
}
