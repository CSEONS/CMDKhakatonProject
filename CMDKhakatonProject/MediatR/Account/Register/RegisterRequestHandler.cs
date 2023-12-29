using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
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
        private readonly IRepository<Restaurant> _restaurantsRepository;
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly IPhotoRepository _photoRepository;

        public RequestRequestHandler(UserManager<AppUser> userManager, IRepository<Restaurant> restaurantRepository, IDatabaseService databaseService, IMapper mapper, IPhotoRepository photoRepository)
        {
            _userManager = userManager;
            _restaurantsRepository = restaurantRepository;
            _databaseService = databaseService;
            _mapper = mapper;
            _photoRepository = photoRepository;
        }

        public async Task<IActionResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            if (await _userManager.ExistByName(request.Username))
                return new BadRequestObjectResult(new { error = ActionMessages.UsernameTaken(request.Username) });

            if (await _userManager.ExistByEmail(request.Username))
                return new BadRequestObjectResult(new { error = ActionMessages.UsernameTaken(request.Username) });

            await _databaseService.BeginTransactionAsync();



            AppUser registeringUser = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = request.Username,
                Email = request.Email,
                PhotoBase64 = request.BannerPhotoBase64
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



            //TODO: Сделать тут рефактор
            #region TODO
            if (request.Role == "user")
            {
                await _userManager.AddToRoleAsync(registeringUser, "user");
            }
            if (request.Role == "restaurant")
            {
                await _userManager.AddToRoleAsync(registeringUser, "restaurant");

                Restaurant restourant = new()
                {
                    Id = registeringUser.Id,
                    Name = request.Username,
                    LogoBase64 = request.LogoPhotoBase64,
                    PhotoBase64 = request.BannerPhotoBase64,
                    Address = request.Address
                };

                _restaurantsRepository.Add(restourant);
            }
            #endregion

            var userViewModel = _mapper.Map<AppUser, ViewModels.AppUser>(registeringUser);

            return new OkObjectResult(new { message = ActionMessages.UserCreated(), user = userViewModel });
        }

    }
}
