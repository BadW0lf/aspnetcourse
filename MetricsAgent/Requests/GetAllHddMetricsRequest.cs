using System;

namespace MetricsAgent.Client
{
    public class GetAllHddMetricsRequest
    {
        public TimeSpan FromTime { get; set; }

        public TimeSpan ToTime { get; set; }
    }
}