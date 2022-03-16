using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : Controller
    {
        private readonly AgentHolder _holder;

        AgentsController(AgentHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _holder.Add(agentInfo);
            return Ok();
        }

        [HttpGet, Route("read")]
        public IEnumerable<AgentInfo> Read()
        {
            return _holder.Values.ToArray();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

    }
}
