using CMDKhakatonProject.MediatR.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.Areas.User
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> GetOrders([FromRoute] string userId, [FromQuery] int start, [FromQuery] int count)
        {
            GetOrdersRequest request = new()
            {
                UserId = userId,
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }

        [HttpPost("AddDishToBasket")]
        public async Task<IActionResult> AddDishToBasket(AddDishToBasketRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }

        [HttpPost("DeleteDishFromBasket")]
        public async Task<IActionResult> DeleteDishFromBasket(DeleteDishFromBasketRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }

        [HttpGet("Basket")]
        public async Task<IActionResult> GetBasket()
        {
            GetBasketRequest request = new()
            {
                User = User,
            };

            return await _mediator.Send(request);
        }

        [HttpGet("Me")]
        public async Task<IActionResult> GetMe()
        {
            MeRequest request = new()
            {
                User = User
            };

            return await _mediator.Send(request);
        }
    }
}
