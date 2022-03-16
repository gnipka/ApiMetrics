using Microsoft.AspNetCore.Mvc;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : Controller
    {
        [HttpGet("available")]
        public IActionResult GetMetricsFromAgent()
        {
            return Ok();
        }
    }
}
