using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.User
{
    public class DeleteDishFromBasketRequestHandler : IRequestHandler<DeleteDishFromBasketRequest, IActionResult>
    {
        private readonly IRepository<DishOrder> _dishOrderRepository;
        private readonly UserManager<AppUser> _userManager;

        public DeleteDishFromBasketRequestHandler(UserManager<AppUser> userManager, IRepository<DishOrder> dishOrderRepository)
        {
            _userManager = userManager;
            _dishOrderRepository = dishOrderRepository;
        }

        public async Task<IActionResult> Handle(DeleteDishFromBasketRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound());

            var deletedOrder =_dishOrderRepository
                                .GetAll()
                                .Where(o => o.OwnerId == user.Id)
                                .FirstOrDefault(o => o.Id == request.OrderId);

            if (deletedOrder is null)
                return new BadRequestObjectResult(ActionMessages.DishOrderNotFound());

            _dishOrderRepository.Delete(deletedOrder);

            return new OkObjectResult(ActionMessages.DishOrderDeleted());
        }
    }
}
