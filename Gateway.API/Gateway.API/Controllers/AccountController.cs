using Gateway.API.ApiResponse;
using Gateway.API.Helpers;
using Gateway.API.Requests.User;
using Gateway.API.Responses.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly string _baseUrl;
        public AccountController(IConfiguration config)
        {
            _baseUrl = config["Microservices:Authentication"];

        }

        [HttpPost("login")]
        public async Task<ApiResponse<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/account/login";
            var response = await HttpClientHelper.PostAsync<ApiResponse<LoginResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }

        [HttpPost("register")]
        public async Task<ApiResponse<CreateUserResponse>> Register([FromBody] CreateUserRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/account/register";
            var response = await HttpClientHelper.PostAsync<ApiResponse<CreateUserResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }

        [HttpPost("courier/register")]
        [Authorize(Roles="admin")]
        public async Task<ApiResponse<CreateUserResponse>> PostCourier([FromBody] CreateUserRequest request)
        {
            string token = Request.Headers.Authorization;
            var json = JsonConvert.SerializeObject(request);
            string url = $"{_baseUrl}/account/courier/register";
            var response = await HttpClientHelper.PostAsync<ApiResponse<CreateUserResponse>>(url, json, token);
            Response.StatusCode = response.Code;
            return response;
        }
        [HttpGet("courier")]
        [Authorize(Roles = "admin,courier")]
        public async Task<ApiResponse<GetEmployeeResponse>> GetCourier(int courierId)
        {
            string token = Request.Headers.Authorization;
            string url = $"{_baseUrl}/account/courier?courierId={courierId}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<GetEmployeeResponse>>(url, token);
            Response.StatusCode = response.Code;
            return response;
        }
        [HttpGet("couriers")]
        [Authorize(Roles = "admin")]
        public async Task<ApiResponse<IEnumerable<GetEmployeeResponse>>> GetCouriers(int currentPage = 1, int perPage = 10)
        {
            string token = Request.Headers.Authorization;
            string url = $"{_baseUrl}/account/couriers?currentPage={currentPage}&perPage={perPage}";
            var response = await HttpClientHelper.GetAsync<ApiResponse<IEnumerable<GetEmployeeResponse>>>(url, token);
            Response.StatusCode = response.Code;
            return response;
        }
    }
}
