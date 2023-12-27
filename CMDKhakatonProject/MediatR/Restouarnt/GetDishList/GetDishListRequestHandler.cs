using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class GetDishListRequestHandler : IRequestHandler<GetDishListRequest, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Dish> _dishRepository;

        public GetDishListRequestHandler(IMapper mapper, IRepository<Dish> repository)
        {
            _mapper = mapper;
            _dishRepository = repository;
        }

        public async Task<IActionResult> Handle(GetDishListRequest request, CancellationToken cancellationToken)
        {
            List<Dish> dishList = _dishRepository
                                    .GetAll()
                                    .Skip(request.Start)
                                    .Take(request.Count)
                                    .ToList();

            return new OkObjectResult(dishList);
        }
    }
}
