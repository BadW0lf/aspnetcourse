using MetricsAgent.Responses;

namespace MetricsAgent.Client
{
    public interface IMetricsAgentClient
    {
        AllCpuMetricsResponse GetCpuMetrics(GetAllCpuMetricsRequest request);

        AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsRequest request);

        AllHddMetricsResponse GetAllHddMetrics(GetAllHddMetricsRequest request);

        GcHeapMetricsResponse GetGcHeapMetrics(GetGcHeapMetrisRequest request);
    }
}
