using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Response;
using CMDKhakatonProject.Service;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CMDKhakatonProject.MediatR.User
{
    public class AddDishToBasketRequestHandler : IRequestHandler<AddDishToBasketRequest, IActionResult>
    {
        private readonly IRepository<DishOrder> _dishOrderRepository;
        private readonly UserManager<AppUser> _userManager;

        public AddDishToBasketRequestHandler(IRepository<DishOrder> dishOrderRepository)
        {
            _dishOrderRepository = dishOrderRepository;
        }

        public async Task<IActionResult> Handle(AddDishToBasketRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(request.User);

            var dishOrder = new DishOrder
            {
                Id = Guid.NewGuid().ToString(),
                OwnerId = user.Id,
                DishId = request.DishId,
                Amount = request.Amont,
                Status = DishOrderStatus.Basket,
                Description = request.Description
            };

            _dishOrderRepository.Add(dishOrder);

            return new OkResult();
        }
    }
}
