using Auth.Infrastructure.Commands;
using Auth.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Auth.Infrastructure.Responses;
using Auth.Data.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Auth.Infrastructure.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<LoginResponse>(result, 200));
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand request)
        {
            request.IsCourier = false;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateUserResponse>(result, 200));
        }

        [HttpPost("courier/register")]
        [Authorize(Roles="admin")]
        public async Task<IActionResult> PostCourier([FromBody] CreateUserCommand request)
        {
            request.IsCourier = true;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateUserResponse>(result, 200));
        }
        [HttpGet("courier")]
        [Authorize(Roles = "admin,courier")]
        public async Task<IActionResult> GetCourier(int courierId)
        {
            GetEmployeeQuery request = new GetEmployeeQuery();
            request.UserId = courierId;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<GetEmployeeResponse>(result, 200));
        }
        [HttpGet("couriers")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> GetCouriers(int currentPage = 1, int perPage = 10)
        {
            GetEmployeesQuery request = new GetEmployeesQuery();
            request.Pagination.CurrentPage = currentPage;
            request.Pagination.CountPerPage = perPage;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<GetEmployeeResponse>>(result, 200, result.Count()));
        }
    }
}
