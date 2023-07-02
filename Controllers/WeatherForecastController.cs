using Microsoft.AspNetCore.Mvc;

namespace RestXMLAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("get.{format}"), FormatFilter]
        public IEnumerable<WeatherForecast> Get2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("post.{format}"), FormatFilter] // ACCEPTS BOTH JSON AND XML, RETURNS BOTH JSON AND XML
        public IActionResult Post(CreatePostRequest request)
        {
            var body = request.Name;
            var head = request.Tag;
            //return Ok(new
            //{
            //    name = "Nick",
            //    tag = head
            //});
            return Ok(request);
        }

    }
}