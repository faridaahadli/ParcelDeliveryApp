using Gateway.API.Hubs;
using Gateway.API.Services.Abstract;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace Gateway.API.BackgroundServices
{
    public class DeliveryTrackService:BackgroundService
    {
        private readonly IRedisService _redisService;
        private readonly IConfiguration _config;
        private readonly IHubContext<TrackHub> _hubContext;
        public DeliveryTrackService(IRedisService redisService,IHubContext<TrackHub> hubContext,
            IConfiguration config)
        {
            _redisService = redisService;
            _hubContext = hubContext;
            _config = config.GetSection("RedisSettings");   
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Process();
            }

        }

        private async Task Process()
        {
            string key = _config.GetSection("ListName").Value;
            string message = await _redisService.PopList(key);
            if (message == null)
                return;
            await _hubContext.Clients.All.SendAsync(message);
        }
    }
}
