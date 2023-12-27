using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class GetRestaurantDishListRequestHandler : IRequestHandler<GetRestaurantDishListRequest, IActionResult>
    {
        private readonly IRepository<Dish> _dishRepository;

        public GetRestaurantDishListRequestHandler(IRepository<Dish> dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<IActionResult> Handle(GetRestaurantDishListRequest request, CancellationToken cancellationToken)
        {
            List<Dish> dishes = _dishRepository
                                .GetAll()
                                .Where(d => d.RestourantId == request.RestaurantId)
                                .Skip(request.Start)
                                .Take(request.Count)
                                .ToList();

            return new OkObjectResult(dishes);
        }
    }
}
