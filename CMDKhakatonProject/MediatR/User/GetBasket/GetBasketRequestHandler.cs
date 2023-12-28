using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.User
{
    public class GetBasketRequestHandler : IRequestHandler<GetBasketRequest, IActionResult>
    {
        private readonly IRepository<DishOrder> _dishOrderRepository;
        private readonly UserManager<AppUser> _userManager;

        public GetBasketRequestHandler(UserManager<AppUser> userManager, IRepository<DishOrder> dishOrderRepository)
        {
            _userManager = userManager;
            _dishOrderRepository = dishOrderRepository;
        }

        public async Task<IActionResult> Handle(GetBasketRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound());

            var basket = _dishOrderRepository
                            .GetAll()
                            .Where(o => o.Status == DishOrderStatus.Basket)
                            .Where(o => o.OwnerId == user.Id)
                            .ToList();

            return new OkObjectResult(basket);
        }
    }
}
