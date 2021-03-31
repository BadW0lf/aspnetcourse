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
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("hddmetrics/from/{fromTime}/to/{toTime}")]
        public AllHddMetricsResponse GetHddMetrics([FromRoute] long fromTime, [FromRoute] long toTime)
        {
            return new AllHddMetricsResponse();
        }
    }
}
