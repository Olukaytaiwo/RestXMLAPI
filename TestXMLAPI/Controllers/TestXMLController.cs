using Microsoft.AspNetCore.Mvc;

namespace TestXMLAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestXMLController : ControllerBase
    {
        
        [HttpPost("CallXML")]
        public IActionResult CallXML(CreatePostRequest request)
        {

            var sendPayload = RestPostIntegration.PostIntegration<CreatePostRequest>(request, "https://localhost:7237/api/WeatherForecast/post.xml");
            return Ok(sendPayload);
        }

    }
}
