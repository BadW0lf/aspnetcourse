using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Controllers
{
    [Route("api/cpumetrics")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ICpuMetricsRepository repository;

        private readonly IMapper mapper;

        public CpuMetricsController(ICpuMetricsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        /// <summary>
        /// Получает метрики CPU на заданном диапазоне времени
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET cpumetrics/from/1/to/9999999999
        ///
        /// </remarks>
        /// <param name="fromTime">начальная метрка времени в секундах с 01.01.1970</param>
        /// <param name="toTime">конечная метрка времени в секундах с 01.01.1970</param>
        /// <returns>Список метрик, которые были сохранены в заданном диапазоне времени</returns>
        /// <response code="201">Если все хорошо</response>
        /// <response code="400">если передали не правильные параетры</response>  
        [HttpGet("cpumetrics/from/{fromTime}/to/{toTime}")]
        public AllCpuMetricsResponse GetCpuMetrics([FromRoute] long fromTime, [FromRoute] long toTime)
        {
            return new AllCpuMetricsResponse
            {
                Metrics = new List<CpuMetricDto>
                {
                    new CpuMetricDto
                    {
                        Id = 1,
                        Time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds()),
                        Value = 12
                    },
                    new CpuMetricDto
                    {
                        Id = 2,
                        Time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.AddSeconds(5).ToUnixTimeSeconds()),
                        Value = 15
                    },
                    new CpuMetricDto
                    {
                        Id = 3,
                        Time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.AddSeconds(10).ToUnixTimeSeconds()),
                        Value = 1
                    },
                }
            };
        }

        /*[HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<CpuMetric> metrics = repository.GetAll();

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<CpuMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            repository.Create(new CpuMetric
            {
                Time = TimeSpan.FromSeconds(request.Time),
                Value = request.Value
            });

            return Ok();
        }*/
    }
}


