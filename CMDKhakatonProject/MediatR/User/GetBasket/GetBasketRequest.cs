using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMDKhakatonProject.MediatR.User
{
    public class GetBasketRequest : IRequest<IActionResult>
    {
        public ClaimsPrincipal? User { get; set; }
    }
}
