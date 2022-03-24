using ApiMetrics.ClassMetric;
using ApiMetrics.DAL;
using ApiMetrics.Requests;
using ApiMetrics.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : Controller
    {
        private IHddMetricsRepository repository;
        public HddMetricsController(IHddMetricsRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric
            {
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new HddMetricDto
                {
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        //private readonly ILogger<AgentInfo> _logger;

        //HddMetricsController(ILogger<AgentInfo> logger)
        //{
        //    _logger = logger;
        //    _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        //}

        //[HttpGet("left")]
        //public IActionResult GetMetricsFromAgent()
        //{
        //    _logger.LogInformation($"Вызван метод сбора метрик HDD без параметров");

        //    return Ok();
        //}
    }
}
