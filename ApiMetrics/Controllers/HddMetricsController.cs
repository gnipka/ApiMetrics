using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : Controller
    {
        private readonly ILogger<AgentInfo> _logger;

        HddMetricsController(ILogger<AgentInfo> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }

        [HttpGet("left")]
        public IActionResult GetMetricsFromAgent()
        {
            _logger.LogInformation($"Вызван метод сбора метрик HDD без параметров");

            return Ok();
        }
    }
}
