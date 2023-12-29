using CMDKhakatonProject.Authorization;
using CMDKhakatonProject.Authorization.Interfaces;
using CMDKhakatonProject.AutoMapper;
using CMDKhakatonProject.Domain;
using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Service.Interfaces;
using CMDKhakatonProject.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using CMDKhakatonProject.Domain.Interfaces;
using CMDKhakatonProject.Domain.Repositories.EF;
using CMDKhakatonProject.Domain.Repositories.Photo;

namespace VolgaIt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.Bind("Config", new Config());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IDatabaseService, DatabaseService>();
            builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
            builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

            builder.Services.AddTransient<IRepository<Courier>, EFCourierRepository>();
            builder.Services.AddTransient<IRepository<Restaurant>, EFRestourantRepository>();
            builder.Services.AddTransient<IRepository<Dish>, EFDishRepository>();
            builder.Services.AddTransient<IRepository<DishOrder>, EFDishOrderRepository>();
            builder.Services.AddTransient<IRepository<Reservation>, EFReservationRepository>();
            builder.Services.AddTransient<IRepository<Present>, EFPresentRepository>();

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Config.ConnectionString));

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                    };
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithExposedHeaders("Content-Disposition")
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                });
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}