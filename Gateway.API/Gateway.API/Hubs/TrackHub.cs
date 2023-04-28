using Microsoft.AspNetCore.SignalR;

namespace Gateway.API.Hubs
{
    public class TrackHub:Hub
    {
        public async void SendMessage(string message)
        {
            await Clients.All.SendAsync("sendmessage", message);
        }
    }
}
