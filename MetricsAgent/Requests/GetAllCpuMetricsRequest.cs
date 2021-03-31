using System;

namespace MetricsAgent.Client
{
    public class GetAllCpuMetricsRequest
    {
        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}