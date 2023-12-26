using CMDKhakatonProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CMDKhakatonProject.Service
{
    public static class Extensions
    {
        public static async Task<bool> ExistByName(this UserManager<AppUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);

            return user != null;
        }

        public static async Task<bool> ExistById(this UserManager<AppUser> userManager, string username)
        {
            var user = await userManager.FindByIdAsync(username);

            return user != null;
        }

    }
}
