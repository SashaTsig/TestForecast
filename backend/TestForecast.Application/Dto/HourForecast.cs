using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Dto
{
    public class HourForecast
    {
        public DateTimeDto Time { get; set; }

        public decimal Temperature { get; set; }

        public decimal WindSpeed { get; set; }

        public string WindDirection { get; set; }

        public bool IsRain { get; set; }
        public bool IsSnow { get; set; }
    }
}
