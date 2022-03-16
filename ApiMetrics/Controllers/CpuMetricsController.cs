using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : Controller
    {
        private readonly ILogger<AgentInfo> _logger;

        CpuMetricsController(ILogger<AgentInfo> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] double percentile)
        {
            _logger.LogInformation($"Вызван метод сбора характеристик CPU с параметрами - время с {fromTime} до {toTime} и персентиль {percentile}");

            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Вызван метод сбора характеристик CPU с параметрами - время с {fromTime} до {toTime}");

            return Ok();
        }
    }
}
