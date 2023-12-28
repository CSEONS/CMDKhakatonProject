using CMDKhakatonProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CMDKhakatonProject.Domain
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Restaurant> Restournats { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dish>()
                .HasOne(d => d.Restourant) // Указываем, что Dish имеет один Restourant
                .WithMany(r => r.Dishes) // Указываем, что Restourant имеет много Dish
                .HasForeignKey(d => d.RestourantId); // Указываем внешний ключ

            base.OnModelCreating(builder);
        }
    }
}
