using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestForecast.Application.Dto;
using TestForecast.Application.Logger;
using TestForecast.Application.Services.Interfaces;

namespace TestForecast.Web.Controllers
{
    [RoutePrefix("api/forecast")]
    public class ForecastController : ApiController
    {
        // GET api/<controller>
        private readonly ILogger _logger;
        private readonly IForecastService _forecastService;

        public ForecastController(ILogger log, IForecastService service)
        {
            _logger = log;
            _forecastService = service;
        }


        [ResponseType(typeof(ForecastDto))]
        public IHttpActionResult Get(double lat, double lon)
        {
            var result = _forecastService.GetForecast(lat, lon);

            return Ok(result);
        }
    }
}