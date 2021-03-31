using MetricsAgent.DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
        // Инжектируем DI провайдер
        private readonly IServiceProvider _provider;
        
        // счетчик для метрики CPU
        private PerformanceCounter cpuCounter;
        public CpuMetricJob(IServiceProvider provider)
        {
            _provider = provider;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            // Создаем новый скоуп
            using (var scope = _provider.CreateScope())
            {
                // получаем наш репозиторий
                var repository = scope.ServiceProvider.GetService<ICpuMetricsRepository>();

                // получаем значение занятости CPU
                var cpuUsageInPercents = Convert.ToInt32(cpuCounter.NextValue());

                // узнаем когда мы сняли значение метрики.
                var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

                // теперь можно записать что-то при помощи репозитория

                repository.Create(new Models.CpuMetric { Time = time, Value = cpuUsageInPercents });
            }

            return Task.CompletedTask;
        }
    }
}
