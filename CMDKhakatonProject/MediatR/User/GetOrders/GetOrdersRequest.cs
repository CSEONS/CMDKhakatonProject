using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.User
{
    public class GetOrdersRequest : IRequest<IActionResult>
    {
        public string UserId { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
