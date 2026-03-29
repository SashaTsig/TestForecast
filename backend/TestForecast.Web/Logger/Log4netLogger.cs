using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForecast.Application.Logger;

namespace TestForecast.Web.Logger
{
    public class Log4netLogger : ILogger
    {
        private readonly ILog _log;

        public Log4netLogger(Type type)
        {
            _log = LogManager.GetLogger(type);
        }

        public Log4netLogger(string name)
        {
            _log = LogManager.GetLogger(name);
        }

        public void Debug(string message)
        {
            if (!String.IsNullOrEmpty(message))
                _log.Debug(message);
        }

        public void Error(string message)
        {
            if (!String.IsNullOrEmpty(message)) 
                _log.Error(message);
        }

        public void Error(Exception exception)
        {
            _log.Error(exception);
        }

        public void Info(string message)
        {
            if (!String.IsNullOrEmpty(message))
                _log.Info(message);
        }

        public void Warning(string message)
        {
            if (!String.IsNullOrEmpty(message))
                _log.Warn(message);
        }
    }
}
