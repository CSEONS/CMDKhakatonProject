using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Account
{
    public class LoginRequest : IRequest<IActionResult>
    {
        public string Username { get; internal set; }
        public string Password { get; internal set; }
    }
}
