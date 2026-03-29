using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Dto
{
    public class DateForecast
    {
        public DateTimeDto Date { get; set; }

        public IEnumerable<HourForecast> Hours { get; set; }
    }
}
