using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("systemdetails")]
        public string GetSystemDetails()
        {
            dynamic response = new ExpandoObject();
            response.HostName = Environment.MachineName;
            response.LocalIPAddress = Request.HttpContext.Connection.LocalIpAddress.ToString();
            response.LocalPort = Request.HttpContext.Connection.LocalPort.ToString();
            response.RemoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            response.RemotePort = Request.HttpContext.Connection.RemotePort.ToString();
            response.RequestHeaders = Request.HttpContext.Request.Headers;
            response.EnvVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            return JsonConvert.SerializeObject(response);
        }
}
