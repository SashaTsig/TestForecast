using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using TestForecast.Web.Filters;

namespace TestForecast.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

            var exceptionFilter = (GlobalExceptionFilter) GlobalConfiguration.Configuration
                .DependencyResolver
                .GetService(typeof(GlobalExceptionFilter));

            config.Filters.Add(exceptionFilter);

           

            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
