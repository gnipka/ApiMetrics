using Microsoft.AspNetCore.Mvc;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : Controller
    {
        [HttpGet("left")]
        public IActionResult GetMetricsFromAgent()
        {
            return Ok();
        }
    }
}
