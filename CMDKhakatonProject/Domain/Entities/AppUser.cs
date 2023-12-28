using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CMDKhakatonProject.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public virtual ICollection<DishOrder> DishOrders { get; set; }
        public string? AccesToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
