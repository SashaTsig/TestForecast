using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForecast.Application.Logger;

namespace TestForecast.Web.Logger
{
    public static class Log4netFactory
    {
        public static ILogger GetLogger<T>()
        {
            return new Log4netLogger(typeof(T));
        }

        public static ILogger GetLogger(Type type)
        {
            return new Log4netLogger(type);
        }

        public static ILogger GetLogger(string name)
        {
            return new Log4netLogger(name);
        }
    }
}
