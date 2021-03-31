using System;

namespace MetricsAgent.Client
{
    public class GetAllRamMetricsRequest
    {
        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}