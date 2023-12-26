using CMDKhakatonProject.Domain.Entities;

namespace CMDKhakatonProject.Authorization.Interfaces
{
    public interface IJwtGenerator
    {
        string Generate(AppUser user, TimeSpan timeSpan);
    }
}
