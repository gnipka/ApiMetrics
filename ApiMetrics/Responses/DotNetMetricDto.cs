using System;

namespace ApiMetrics.Responses
{
    public class DotNetMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
