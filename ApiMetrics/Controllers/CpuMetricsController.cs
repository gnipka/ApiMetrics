using ApiMetrics.ClassMetric;
using ApiMetrics.DAL;
using ApiMetrics.Requests;
using ApiMetrics.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiMetrics.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ICpuMetricsRepository repository;

        public CpuMetricsController(ICpuMetricsRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new CpuMetric
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
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            return Ok(response);
        }

        //private readonly ILogger<AgentInfo> _logger;

        //CpuMetricsController(ILogger<AgentInfo> logger)
        //{
        //    _logger = logger;
        //    _logger.LogDebug(1, "NLog встроен в CpuMetricsController");
        //}

        // Тестовое обращение к бд
        //[HttpGet("sql-test")]
        //public IActionResult TryToSqlLite()
        //{
        //    string cs = "Data Source=:memory:";
        //    string stm = "SELECT SQLITE_VERSION()";
        //    using (var con = new SQLiteConnection(cs))
        //    {
        //        con.Open();
        //        using var cmd = new SQLiteCommand(stm, con);
        //        string version = cmd.ExecuteScalar().ToString();
        //        return Ok(version);
        //    }
        //}


        //[HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime, [FromRoute] double percentile)
        //{
        //    _logger.LogInformation($"Вызван метод сбора характеристик CPU с параметрами - время с {fromTime} до {toTime} и персентиль {percentile}");

        //    return Ok();
        //}

        //[HttpGet("from/{fromTime}/to/{toTime}/")]
        //public IActionResult GetMetricsFromAgent([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"Вызван метод сбора характеристик CPU с параметрами - время с {fromTime} до {toTime}");

        //    return Ok();
        //}
    }
}
