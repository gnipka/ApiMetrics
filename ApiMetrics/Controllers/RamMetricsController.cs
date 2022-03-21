using ApiMetrics.ClassMetric;
using ApiMetrics.DAL;
using ApiMetrics.Requests;
using ApiMetrics.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : Controller
    {
        private IRamMetricsRepository repository;

        public RamMetricsController(IRamMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            repository.Create(new RamMetric
            {
                Value = request.Value
            });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto
                {
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        //private readonly ILogger<AgentInfo> _logger;

        //RamMetricsController(ILogger<AgentInfo> logger)
        //{
        //    _logger = logger;
        //    _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        //}

        //[HttpGet("available")]
        //public IActionResult GetMetricsFromAgent()
        //{
        //    _logger.LogInformation($"Вызван метод сбора метрик RAM без параметров");

        //    return Ok();
        //}
    }
}
