using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : Controller
    {
        private readonly ILogger<AgentInfo> _logger;

        RamMetricsController(ILogger<AgentInfo> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }

        [HttpGet("available")]
        public IActionResult GetMetricsFromAgent()
        {
            _logger.LogInformation($"Вызван метод сбора метрик RAM без параметров");

            return Ok();
        }
    }
}
