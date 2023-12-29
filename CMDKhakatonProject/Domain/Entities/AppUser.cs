using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CMDKhakatonProject.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Id {  get; set; }
        public string? PhotoBase64 { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<DishOrder> DishOrders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public string? AccesToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
