using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.UI.WebControls;
using TestForecast.Application.Dto;
using TestForecast.Application.Exceptions;
using TestForecast.Application.Logger;

namespace TestForecast.Web.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            
            var response = new ErrorDto
            {
                Timestamp = DateTime.Now,
                ErrorMessage = exception.Message,
            };

            HttpStatusCode statusCode;

            if (exception is BadRequestException)
            {
                statusCode = HttpStatusCode.NotFound;
                _logger.Warning($"Bad Request: {exception.Message}");
            }
           
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                _logger.Error(exception);

            }

            /*context.Response = new
                HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                        Content = new StringContent(JsonConvert.SerializeObject(response), System.Text.Encoding.UTF8, "application/json")
                };*/

            context.Response = context.Request.CreateResponse(statusCode, response);
        }
    }
}