using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class AddDishRequestHandler : IRequestHandler<AddDishRequest, IActionResult>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Dish> _dishRepository;
        private readonly IPhotoRepository _photoRepository;
        private readonly UserManager<AppUser> _userManager;

        public AddDishRequestHandler(IMapper mapper, IRepository<Dish> dishRepository, IPhotoRepository photoRepository, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _dishRepository = dishRepository;
            _photoRepository = photoRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Handle(AddDishRequest request, CancellationToken cancellationToken)
        {
            Dish dish = _mapper.Map<Dish>(request);

            var user = await _userManager.GetUserAsync(request.User);

            /*if (user is null)
                return new BadRequestObjectResult(ActionMessages.UserNotFound());*/

            //dish.PhotosBase64 = _photoRepository.UploadAsBase64(request.Photos);
            dish.PreviewPhoto = (request.PreviewPhotoBase64);

            dish.RestourantId = user?.Id;

            _dishRepository.Add(dish);

            return new OkObjectResult(dish);  
        }
    }
}
