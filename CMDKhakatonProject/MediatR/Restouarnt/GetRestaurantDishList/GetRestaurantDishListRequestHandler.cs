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
            var dishes = _dishRepository
                .GetAll()
                .Where(d => d.RestourantId == request.RestaurantId);

            if (request.MinPrice > 0)
                dishes = dishes.Where(d => d.Price > request.MinPrice);

            if (request.MaxPrice > 0)
                dishes = dishes.Where(d => d.Price < request.MaxPrice);

            if (request.MaxRating > 0)
                dishes = dishes.Where(d => d.Rating < request.MaxRating);

            if (request.MinPrice > 0)
                dishes = dishes.Where(d => d.Rating > request.MinPrice);

            if (request.Tgas?.Length > 0)
                dishes = dishes.Where(d => d.Tags.Select(t => t.Name).Intersect(request.Tgas).Any());

            dishes = dishes
                .Skip(request.Start)
                .Take(request.Count)
                .ToList();

            return new OkObjectResult(dishes);
        }
    }
}
