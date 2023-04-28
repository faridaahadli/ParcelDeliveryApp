using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderDelivery.Infrastructure.Commands;
using OrderDelivery.Infrastructure.Responses;
using OrderDeliveryService.API.ApiResponse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderDeliveryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DeliveryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("create")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Post([FromBody] CreateDeliveryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(new ApiResponse<CreateDeliveryResponse>(result, 200));
        }

       
    }
}
