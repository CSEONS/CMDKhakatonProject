using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CMDKhakatonProject.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; internal set; }
        public string AccesToken { get; internal set; }
        public string RefreshToken { get; internal set; }
    }
}
