using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("range")]
        public IActionResult GetForecastForDays([FromQuery] int days = 3)
        {
            if (days <= 0 || days > 14)
            {
                return BadRequest("Your range should be between 1 and 14!");
            }

            var result = Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });

            return Ok(result);
        }


        private static List<WeatherForecast> _customForecasts = new();

        [HttpPost("add")]
        public ActionResult AddForecast([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
                return BadRequest();

            _customForecasts.Add(forecast);

            return Ok(new
            {
                Message = "Forecast added successfully",
                TotalCustomForecasts = _customForecasts.Count
            });
        }



    }
}
