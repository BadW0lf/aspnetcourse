using System;

namespace MetricsAgent.Client
{
    public class GetGcHeapMetrisRequest
    {
        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}