using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestForecast.Application.Logger;
using TestForecast.Application.Services.Implementation;
using TestForecast.Application.Services.Interfaces;
using TestForecast.Web.Filters;
using TestForecast.Web.Logger;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace TestForecast.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(WebApiApplication));
        protected void Application_Start()
        {
            InitializeLog4Net();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }




        private void InitializeLog4Net()
        {
            var log4NetConfigPath = Server.MapPath("~/log4net.config");

            if (File.Exists(log4NetConfigPath))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigPath));
                _log.Info("log4net initialized from configuration file");
            }
            else
            {
                BasicConfigurator.Configure();
                _log.Warn("log4net.config not found, using basic configuration");
            }
        }
    }
}
