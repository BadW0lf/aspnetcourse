using MetricsAgent.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        [HttpGet("rammetrics/from/{fromTime}/to/{toTime}")]
        public AllRamMetricsResponse GetRamMetrics([FromRoute] long fromTime, [FromRoute] long toTime)
        {
            return new AllRamMetricsResponse();
        }
    }
}
