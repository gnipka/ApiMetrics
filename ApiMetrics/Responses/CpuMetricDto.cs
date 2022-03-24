using System;

namespace ApiMetrics.Responses
{
    public class CpuMetricDto : MetricDto
    {
        public TimeSpan Time { get; set; }

    }
}
