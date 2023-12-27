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
        public async Task<IActionResult> GetDishList([FromBody] GetDishListRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("DishList/{restaurantId}")]
        public async Task<IActionResult> GetRestaurantDishList([FromRoute] Guid restaurantId, [FromBody] GetRestaurantDishListRequest request)
        {
            request.RestaurantId = restaurantId;

            return await _mediator.Send(request);
        }

        [HttpPost("AddDish")]
        public async Task<IActionResult> AddDish([FromForm] AddDishRequest request)
        {
            request.User = User;

            return await _mediator.Send(request);
        }
    }
}
