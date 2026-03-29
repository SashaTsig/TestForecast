using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestForecast.Application.Dto;
using TestForecast.Application.Logger;
using TestForecast.Application.Models.WeatherAPI;
using TestForecast.Application.Services.Interfaces;
using TestForecast.Application.Utils;

namespace TestForecast.Application.Services.Implementation
{
    public class ForecastService : IForecastService
    {
        private readonly RestClient _client;

        private readonly ILogger _logger;

        private readonly IConfigurationService _configurationService;

        private const int FORECAST_DAYS_CONT= 3;

        public ForecastService(ILogger logger, IConfigurationService configurationService)
        {
            _logger = logger;

            _configurationService = configurationService;

            var options = new RestClientOptions(_configurationService.GetWeatherAPIBaseUrl());

            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
        }

        public ForecastDto GetForecast(double lat, double lon)
        {
            var request = new RestRequest("", Method.Get);

            request.AddParameter("key", _configurationService.GetWeatherAPIKey());

            var location = $"{_configurationService.GetWeatherAPIDefaultLat()},{_configurationService.GetWeatherAPIDefaultLon()}";

            request.AddParameter("q", location);
            request.AddParameter("days", FORECAST_DAYS_CONT);

            var response = _client.Execute(request);

            _logger.Info($"Ответ от АПИ: {response.Content}");

            if (response.IsSuccessful)
            {
                var forecast = JsonConvert.DeserializeObject<WeatherAPIResponse>(response.Content);

                return MapForecastToDto(forecast);
            }
            else
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }
        }

        private ForecastDto MapForecastToDto(WeatherAPIResponse forecast)
        {
            var dto = new ForecastDto()
            {
                Location = new LocationDto()
                {
                    Name = forecast.Location.Name,
                    TimeZone = forecast.Location.TimeZone,
                    CurrentTime = new DateTimeDto(DateUtils.ParseWeatherAPIDateTime(forecast.Location.LocalTime))
                }
            };

            var dates = new List<DateForecast>();

            foreach (var day in forecast.Forecast.Days)
            {


                var date = new DateForecast()
                {
                    Date = new DateTimeDto(DateUtils.ParseWeatherAPIDate(day.Date)),
                    Hours = day.Hours.Select(h => new HourForecast()
                    {
                        IsRain =  h.IsRain == 1,
                        IsSnow = h.IsSnow == 1,
                        Temperature = h.Temperature,
                        Time = new DateTimeDto(DateUtils.ParseWeatherAPIDateTime(h.Time)),
                        WindDirection = h.WindDirection,
                        WindSpeed = h.WindSpeed
                    })
                };

                date.Hours = date.Hours.Where(h => dto.Location.CurrentTime.ToDateTime() < h.Time.ToDateTime());

                dates.Add(date);
            }

            dto.Dates = dates;

            return dto;
        }
    }
}
