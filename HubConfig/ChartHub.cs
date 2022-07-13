using Microsoft.AspNetCore.SignalR;
using RealTimeAPIReader.Models;

namespace RealTimeAPIReader.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) =>
            await Clients.All.SendAsync("broadcastchartdata", data);
    }
}