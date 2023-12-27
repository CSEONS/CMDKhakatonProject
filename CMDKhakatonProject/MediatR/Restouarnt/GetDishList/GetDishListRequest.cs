using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class GetDishListRequest : IRequest<IActionResult>
    {
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
