using CMDKhakatonProject.Authorization.Interfaces;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolgaIt;

namespace CMDKhakatonProject.MediatR.Account
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator JwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = JwtGenerator;
        }

        public async Task<IActionResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user is null)
                return new BadRequestObjectResult(new { error = ActionMessages.UserNotFound() });

            var signInResult = await _signInManager.PasswordSignInAsync
            (
                user: user,
                password: request.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (signInResult.Succeeded is false)
                return new BadRequestObjectResult(new { error = ActionMessages.SignInFailed() });

            user.AccesToken = _jwtGenerator.Generate(user, TimeSpan.FromMinutes(Config.AccesTokenExpiredTimePerMinute));
            user.RefreshToken = _jwtGenerator.Generate(user, TimeSpan.FromDays(Config.RefreshTokenExpiredTimePerDays));

            await _userManager.UpdateAsync(user);

            return new OkObjectResult(new {userId = user.Id, accesToken = user.AccesToken, refreshToken = user.RefreshToken});
        }

    }
}
