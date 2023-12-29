using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class SendPresentRequest : IRequest<IActionResult>
    {
        public Guid UserId { get; set; }
        public Guid DishId { get; set; }
    }
}
