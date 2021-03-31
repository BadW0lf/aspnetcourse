using System;
using System.Collections.Generic;

namespace MetricsAgent.Client
{
    public class GcHeapMetricsResponse
    {
        public List<GcHeapMetricDto> Metrics { get; set; }
    }

    public class GcHeapMetricDto
    {
        public TimeSpan Time { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}