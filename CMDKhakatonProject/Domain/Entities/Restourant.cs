using Microsoft.AspNetCore.Identity;

namespace CMDKhakatonProject.Domain.Entities
{
    public class Restourant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string LogoUrl { get; set; }
        public decimal Rating { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
