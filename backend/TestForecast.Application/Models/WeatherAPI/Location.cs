using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Models.WeatherAPI
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tz_id")]
        public string TimeZone { get; set; }

        [JsonProperty("localtime")]
        public string LocalTime { get; set; }


    }
}
