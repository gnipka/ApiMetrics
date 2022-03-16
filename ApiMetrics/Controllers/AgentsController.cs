using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : Controller
    {
        private readonly AgentHolder _holder;
        private readonly ILogger<AgentInfo> _logger;

        AgentsController(AgentHolder holder, ILogger<AgentInfo> logger)
        {
            _holder = holder;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _holder.Add(agentInfo);

            _logger.LogInformation("Вызван метод регистрации агента.");

            return Ok();
        }

        [HttpGet, Route("read")]
        public IEnumerable<AgentInfo> Read()
        {
            _logger.LogInformation("Вызван метод чтения списка агентов.");

            return _holder.Values.ToArray();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation("Вызван метод подключения агента.");

            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _logger.LogInformation("Вызван метод отключения агента.");

            return Ok();
        }

    }
}
