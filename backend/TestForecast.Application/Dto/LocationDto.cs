using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Dto
{
    public class LocationDto
    {
        public string Name { get; set; }

        public string TimeZone { get; set; }

        public DateTimeDto CurrentTime { get; set; }
    }
}
