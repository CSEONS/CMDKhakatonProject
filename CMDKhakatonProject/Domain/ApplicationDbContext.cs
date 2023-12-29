using CMDKhakatonProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Reflection.Emit;

namespace CMDKhakatonProject.Domain
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
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
            AppUser appUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User",
                NormalizedUserName = "USER",
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "User95_1"),
                Role = "restaurant"
            };


            Restaurant restaurant = new()
            {
                Id = appUser.Id,
            };


            builder.Entity<AppUser>()
                .HasData(appUser);

            builder.Entity<Restaurant>()
                .HasData(restaurant);

            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "restaurant", NormalizedName = "RESTAURANT" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "user", NormalizedName = "USER" }
            );

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

            builder.Entity<Reservation>()
                .HasOne(r => r.Reserver)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.ReserverId);

            builder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany()
                .HasForeignKey(r => r.TableId);


            base.OnModelCreating(builder);
        }
    }
}
