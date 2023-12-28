using CMDKhakatonProject.MediatR.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }

        [HttpPost("SignOut")]
        [Authorize]
        public async Task<IActionResult> Lgout(CancellationToken cancellationToken)
        {
            LogoutRequest request = new LogoutRequest()
            {
                User = User
            };

            return await _mediator.Send(request, cancellationToken);
        }

        /*[HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateRequest request, CancellationToken cancellationToken)
        {
            request.User = User;

            return await _mediator.Send(request, cancellationToken);
        }*/
    }

}
