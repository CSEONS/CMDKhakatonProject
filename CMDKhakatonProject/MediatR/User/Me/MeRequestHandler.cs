using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CMDKhakatonProject.MediatR.User
{
    public class MeRequestHandler : IRequestHandler<MeRequest, IActionResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public MeRequestHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(MeRequest request, CancellationToken cancellationToken)
        {
            /*return new OkObjectResult(new ViewModels.AppUser()
            {
                Email = "em@mail.com",
                Role = "restaurant",
                UserName = "User",
            });*/

            var user = await _userManager.GetUserAsync(request.User);
            if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound());

            ViewModels.AppUser viewModel = _mapper.Map<ViewModels.AppUser>(user);

            return new OkObjectResult(viewModel);
        }
    }
}
