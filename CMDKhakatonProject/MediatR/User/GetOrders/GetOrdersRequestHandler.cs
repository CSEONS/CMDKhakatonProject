using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.User
{
    public class GetOrdersRequestHandler : IRequestHandler<GetOrdersRequest, IActionResult>
    {
        private readonly IRepository<DishOrder> _dishOrderRepository;

        public GetOrdersRequestHandler(IRepository<DishOrder> dishOrderRepository)
        {
            _dishOrderRepository = dishOrderRepository;
        }

        public async Task<IActionResult> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            List<DishOrder> orders = _dishOrderRepository
                .GetAll()
                .Where(o => o.OwnerId == request.UserId)
                .Skip(request.Start)
                .Take(request.Count)
                .ToList();

            return new OkObjectResult(orders);
        }
    }
}
