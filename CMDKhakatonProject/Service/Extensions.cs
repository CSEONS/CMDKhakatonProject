using CMDKhakatonProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace CMDKhakatonProject.Service
{
    public static class Extensions
    {
        public static async Task<bool> ExistByName(this UserManager<AppUser> userManager, string username)
        {
            var user = await userManager.FindByNameAsync(username);

            return user != null;
        }

        public static async Task<bool> ExistByEmail(this UserManager<AppUser> userManager, string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            return user != null;
        }

        public static async Task<bool> ExistById(this UserManager<AppUser> userManager, string username)
        {
            var user = await userManager.FindByIdAsync(username);

            return user != null;
        }

        public static void CopyNonNullValues(this object src, object dest)
        {
            var type = dest.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var value = property.GetValue(src);
                if (value != null)
                {
                    property.SetValue(dest, value);
                }
            }
        }
    }
}
