using Gateway.API.ApiResponse;
using Gateway.API.Helpers;
using Gateway.API.Requests.OrderDelivery;
using Gateway.API.Responses.OrderDelivery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly string _baseUrl;
        public OrderController(IConfiguration config)
        {
            _baseUrl = config["Microservices:ParcelDelivery"];
        }

        [HttpGet("admin/orders")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<IEnumerable<GetOrderResponse>>> GetOrdersByAdmin(int currentPage = 1, int perPage = 10)
        {
            string token = Request.Headers.Authorization;           
            string url = $"{_baseUrl}/order/admin/orders?currentPage={currentPage}&perPage={perPage}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<IEnumerable<GetOrderResponse>>>(url,token);
            Response.StatusCode = response.Code;
            return response;
        }


        [HttpGet("user/orders")]
        [Authorize(Roles = "user")]
        public async Task<ApiResponse<IEnumerable<GetOrderResponse>>> GetOrdersByUser(int userId, int currentPage = 1, int perPage = 10)
        {
            string token = Request.Headers.Authorization;
            string url = $"{_baseUrl}/order/user/orders?userId={userId}&currentPage={currentPage}&perPage={perPage}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<IEnumerable<GetOrderResponse>>>(url,token);
            Response.StatusCode = response.Code;
            return response;
        }

        [HttpGet("courier/orders")]
        [Authorize(Roles = "courier")]
        public async Task<ApiResponse<GetOrderResponse>> GetOrdersByCourier(int courierId, int currentPage = 1, int perPage = 10)
        {

            string token = Request.Headers.Authorization;
            string url = $"{_baseUrl}/order/user/orders?courierId={courierId}&currentPage={currentPage}&perPage={perPage}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<GetOrderResponse>>(url, token);
            Response.StatusCode = response.Code;
            return response;
        }



        [HttpGet("user")]
        [Authorize(Roles = "user")]
        public async Task<ApiResponse<GetOrderResponse>> GetOrderByIdUser(int orderId)
        {
            string token = Request.Headers.Authorization;
            string url = $"{_baseUrl}/order/user/orders?orderId={orderId}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<GetOrderResponse>>(url, token);
            Response.StatusCode = response.Code;
            return response;
        }

        // POST api/<OrderController>
        [HttpPost("create")]
        [Authorize(Roles = "user")]
        public async Task<ApiResponse<CreateOrderResponse>> Post([FromBody] CreateOrderRequest request)
        {
            string token = Request.Headers.Authorization;
            var json=JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/order/create";
            var response = await HttpClientHelper.PostAsync<ApiResponse<CreateOrderResponse>>(url,json,token);
            Response.StatusCode = response.Code;
            return response;
        }

        // PUT api/<OrderController>/5
        [HttpPut("user/update")]
        [Authorize(Roles = "user")]
        public async Task<ApiResponse<CreateOrderResponse>> UpdateByUser([FromBody] UpdateOrderByUserRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/order/user/update";
            var response = await HttpClientHelper.PutAsync<ApiResponse<CreateOrderResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }

        [HttpPut("staff/update")]
        [Authorize(Roles = "admin,courier")]
        public async Task<ApiResponse<CreateOrderResponse>> UpdateByStaff([FromBody] UpdateOrderByStaffRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/order/staff/update";
            var response = await HttpClientHelper.PutAsync<ApiResponse<CreateOrderResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }
    }
}
