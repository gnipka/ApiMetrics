using System;

namespace ApiMetrics.Responses
{
    public class DotNetMetricDto : MetricDto
    {
        public TimeSpan Time { get; set; }
    }
}
