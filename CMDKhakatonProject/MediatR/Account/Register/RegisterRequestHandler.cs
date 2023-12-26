using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Response;
using CMDKhakatonProject.Service;
using CMDKhakatonProject.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMDKhakatonProject.MediatR.Account
{
    public class RequestRequestHandler : IRequestHandler<RegisterRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public RequestRequestHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IDatabaseService databaseService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            if (await _userManager.ExistByName(request.Username))
                return new BadRequestObjectResult(new { error = ActionMessages.UsernameTaken(request.Username) });

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return new BadRequestObjectResult(new { error = ActionMessages.InvalidCredintials() });

            await _databaseService.BeginTransactionAsync();

            AppUser registeringUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            object error = new object();

            try
            {
                var createingUserResult = await _userManager.CreateAsync(registeringUser);
                if (createingUserResult.Succeeded is false)
                {
                    error = createingUserResult;
                    throw new Exception();
                }

                var setPasswordResult = await _userManager.AddPasswordAsync(registeringUser, request.Password);
                if (setPasswordResult.Succeeded is false)
                {
                    error = setPasswordResult;
                    throw new Exception();
                }

                await _databaseService.CommitAsync();
            }
            catch (Exception ex)
            {
                await _databaseService.RollbackAsync();
                return new BadRequestObjectResult(error);
            }



            var userViewModel = _mapper.Map<AppUser, ViewModels.AppUser>(registeringUser);

            return new OkObjectResult(new { message = ActionMessages.UserCreated(), user = userViewModel });
        }

    }
}
