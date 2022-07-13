using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeAPIReader.TimerFeatures;
using RealTimeAPIReader.RandomDataStorage;
using RealTimeAPIReader.HubConfig;

namespace RealTimeAPIReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly TimerManager _timer;

        public ChartController(IHubContext<ChartHub> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_timer.IsTimerStarted)
              //  _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", DataManager.GetData()));
            _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferChartData", APIHandler.ApiData.GetApiData()));
            return Ok(new { Message = "Request Completed" });
        }
    }
    public class ApiController : ControllerBase
    {
        private readonly IHubContext<ApiHub> _hub;
        private readonly TimerManager _timer;

        public ApiController(IHubContext<ApiHub> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!_timer.IsTimerStarted)
                _timer.PrepareTimer(() => _hub.Clients.All.SendAsync("TransferAPIData", APIHandler.ApiData.GetApiData()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
