using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderDelivery.Infrastructure.Commands;
using OrderDelivery.Infrastructure.Queries;
using OrderDelivery.Infrastructure.Responses;
using OrderDeliveryService.API.ApiResponse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderDeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("admin/orders")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetOrdersByAdmin(int currentPage = 1, int perPage = 10)
        {
            var request = new GetOrdersByAdminQuery();
            request.Pagination.CurrentPage = currentPage;
            request.Pagination.CountPerPage = perPage;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<GetOrderResponse>>(result, 200, result.Count()));
        }


        [HttpGet("user/orders")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetOrdersByUser(int userId, int currentPage = 1, int perPage = 10)
        {
            var request = new GetOrdersByUserQuery();
            request.IsCourier = false;
            request.Id = userId;
            request.Pagination.CurrentPage = currentPage;
            request.Pagination.CountPerPage = perPage;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<GetOrderResponse>>(result, 200, result.Count()));
        }

        [HttpGet("courier/orders")]
        [Authorize(Roles ="courier")]
        public async Task<IActionResult> GetOrdersByCourier(int courierId, int currentPage = 1, int perPage = 10)
        {
            var request = new GetOrdersByUserQuery();
            request.Id = courierId;
            request.IsCourier = true;
            request.Pagination.CurrentPage = currentPage;
            request.Pagination.CountPerPage = perPage;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<IEnumerable<GetOrderResponse>>(result, 200, result.Count()));
        }


        [HttpGet("user")]
        [Authorize(Roles="user")]
        public async Task<IActionResult> GetOrderByIdUser(int orderId)
        {
            var request = new GetOrderByIdQuery();
            request.IsCourier = false;
            request.Id = orderId;
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<GetOrderResponse>(result, 200));
        }

        // POST api/<OrderController>
        [HttpPost("create")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateOrderResponse>(result, 200));
        }

        // PUT api/<OrderController>/5
        [HttpPut("user/update")]
        //[Authorize(Roles ="user")]
        public async Task<IActionResult> UpdateByUser([FromBody] UpdateOrderByUserCommand request)
        {

            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateOrderResponse>(result, 200));
        }

        [HttpPut("staff/update")]
        [Authorize(Roles="admin,courier")]
        public async Task<IActionResult> UpdateByStaff([FromBody] UpdateOrderByStaffCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateOrderResponse>(result, 200));
        }



    }
}
