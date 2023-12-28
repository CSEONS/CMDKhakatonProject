using AutoMapper;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.MediatR.Restouarnt;

namespace CMDKhakatonProject.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, ViewModels.AppUser>();
            CreateMap<AddDishRequest, Dish>();
        }
    }
}
