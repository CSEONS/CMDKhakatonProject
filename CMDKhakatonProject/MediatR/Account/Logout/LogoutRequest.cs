using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMDKhakatonProject.MediatR.Account
{
    public class LogoutRequest : IRequest<IActionResult>
    {
        public ClaimsPrincipal? User { get; internal set; }
    }
}
