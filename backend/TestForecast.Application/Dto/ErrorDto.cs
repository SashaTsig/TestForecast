using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Dto
{
    public class ErrorDto
    {
        public string ErrorMessage { get; set; }

        public DateTimeOffset Timestamp {  get; set; }
    }
}
