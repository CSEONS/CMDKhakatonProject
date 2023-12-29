using CMDKhakatonProject.MediatR.Restouarnt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.Areas.Restourant
{
    [ApiController]
    [Route("api/Restourant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("DishList")]
        public async Task<IActionResult> GetDishList([FromQuery] int start, [FromQuery] int count)
        {
            GetDishListRequest request = new()
            {
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }

        [HttpGet("DishList/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantDishList([FromRoute] Guid restaurantId, [FromQuery] int start, [FromQuery] int count)
        {
            GetRestaurantDishListRequest request = new()
            {
                RestaurantId = restaurantId,
                Start = start,
                Count = count
            };

            return await _mediator.Send(request);
        }

        [HttpPost("AddDish")]
        public async Task<IActionResult> AddDish([FromForm] AddDishRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }

        [HttpPost("Reserve")]
        public async Task<IActionResult> Resere(ReserveRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }
    }
}
