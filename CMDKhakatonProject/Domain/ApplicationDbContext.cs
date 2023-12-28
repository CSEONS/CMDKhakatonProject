using CMDKhakatonProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Reflection.Emit;

namespace CMDKhakatonProject.Domain
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Restaurant> Restournats { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dish>()
                .HasOne(d => d.Restourant)
                .WithMany(r => r.Dishes)
                .HasForeignKey(d => d.RestourantId);

            builder.Entity<Dish>()
                .HasMany(d => d.Tags)
                .WithMany();

            builder.Entity<DishOrder>()
                .HasOne(d => d.Owner)
                .WithMany(u => u.DishOrders)
                .HasForeignKey(d => d.OwnerId);

            builder.Entity<DishOrder>()
                .HasOne(d => d.Dish)
                .WithMany()
                .HasForeignKey(d => d.DishId);

            base.OnModelCreating(builder);
        }
    }
}
