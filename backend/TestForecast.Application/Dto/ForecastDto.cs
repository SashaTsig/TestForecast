using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Dto
{
    public class ForecastDto
    {
        public LocationDto Location { get; set; }

        public IEnumerable<DateForecast> Dates { get; set; }

        public ForecastDto() { }
    }
}
