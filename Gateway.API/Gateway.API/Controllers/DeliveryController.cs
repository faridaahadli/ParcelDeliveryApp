using Gateway.API.ApiResponse;
using Gateway.API.Helpers;
using Gateway.API.Requests.OrderDelivery;
using Gateway.API.Responses.OrderDelivery;
using Gateway.API.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly string _baseUrl;
        private readonly IRedisService _redisService;
        private readonly IConfiguration _redisConfig;
        public DeliveryController(IConfiguration config, IRedisService redisService)
        {
            _baseUrl = config["Microservices:ParcelDelivery"];
            _redisService = redisService;   
            _redisConfig =config.GetSection("RedisSettings");
        }
        // GET: api/<DeliveryController>
        [HttpPost("create")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<CreateDeliveryResponse>> Post([FromBody] CreateDeliveryRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/delivery/create";
            var response = await HttpClientHelper.PostAsync<ApiResponse<CreateDeliveryResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }
        [HttpPost("track")]
        public async Task<ApiResponse<DeliveryTrackResponse>> Track([FromBody] DeliveryTrackRequest request)
        {
            string listName = _redisConfig.GetSection("ListName").Value;
            string data = JsonConvert.SerializeObject(request);
            await _redisService.PushList(listName, data);           
            return new ApiResponse<DeliveryTrackResponse>();
        }
    }
}
