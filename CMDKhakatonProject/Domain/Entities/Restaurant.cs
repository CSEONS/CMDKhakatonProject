using Microsoft.AspNetCore.Identity;

namespace CMDKhakatonProject.Domain.Entities
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? PhotoBase64 { get; set; }
        public string? LogoBase64 { get; set; }
        public decimal? Rating { get; set; }
        public string? Address { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
