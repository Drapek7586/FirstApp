using Microsoft.AspNetCore.SignalR;
using RealTimeAPIReader.Models;


namespace RealTimeAPIReader.HubConfig
{
    public class ApiHub:Hub
    {
        public async Task BroadcastChartData(List<ApiModel> data) =>
            await Clients.All.SendAsync("BroadcastApiData", data);
    }
}
