using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : Controller
    {
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
