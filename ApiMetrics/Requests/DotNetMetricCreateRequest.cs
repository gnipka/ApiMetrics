using System;

namespace ApiMetrics.Requests
{
    public class DotNetMetricCreateRequest
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
    }
}
