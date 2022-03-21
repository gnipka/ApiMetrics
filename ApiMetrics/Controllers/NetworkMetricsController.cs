using ApiMetrics.ClassMetric;
using ApiMetrics.DAL;
using ApiMetrics.Requests;
using ApiMetrics.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : Controller
    {
        private INetworkMetricsRepository repository;
        public NetworkMetricsController(INetworkMetricsRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest request)
        {
            repository.Create(new NetworkMetric
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
            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new NetworkMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        //private readonly ILogger<AgentInfo> _logger;

        //NetworkMetricsController(ILogger<AgentInfo> logger)
        //{
        //    _logger = logger;
        //    _logger.LogDebug(1, "NLog встроен в NetworkMetricsController");
        //}

        //[HttpGet("from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"Вызван метод сбора метрик сети с параметрами - время с {fromTime} до {toTime}");

        //    return Ok();
        //}
    }
}
