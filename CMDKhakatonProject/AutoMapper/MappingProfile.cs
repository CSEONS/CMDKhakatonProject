using AutoMapper;
using CMDKhakatonProject.Domain.Entities;

namespace CMDKhakatonProject.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, ViewModels.AppUser>();       
        }
    }
}
