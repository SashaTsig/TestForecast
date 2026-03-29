using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForecast.Application.Utils
{
    public static class DateUtils
    {
        private static readonly string WEATHERAPI_DATETIME_FORMAT = "yyyy-MM-dd HH:mm";

        private static readonly string WEATHERAPI_DATE_FORMAT = "yyyy-MM-dd";

        public static DateTime ParseWeatherAPIDateTime(string dateTime)
        {
            if (!DateTime.TryParseExact(dateTime, WEATHERAPI_DATETIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                throw new Exception($"Не удалось распознать дату {dateTime}");

            return dt;
        }

        public static DateTime ParseWeatherAPIDate(string date)
        {
            if (!DateTime.TryParseExact(date, WEATHERAPI_DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                throw new Exception($"Не удалось распознать дату {date}");

            return dt;
        }
    }
}
