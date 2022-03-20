using ApiMetrics.ClassMetric;
using ApiMetrics.DAL;
using ApiMetrics.Requests;
using ApiMetrics.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : Controller
    {
        private IDotNetMetricsRepository repository;
        public DotNetMetricsController(IDotNetMetricsRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            repository.Create(new DotNetMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = repository.GetAll();
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new DotNetMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }
        //private readonly ILogger<AgentInfo> _logger;

        //DotNetMetricsController(ILogger<AgentInfo> logger)
        //{
        //    _logger = logger;
        //    _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");
        //}

        //[HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"Вызван метод сбора количества ошибок с параметрами - время с {fromTime} до {toTime}");

        //    return Ok();
        //}
    }
}
