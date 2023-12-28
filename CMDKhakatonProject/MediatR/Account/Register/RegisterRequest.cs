using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMDKhakatonProject.MediatR.Account
{
    public class RegisterRequest : IRequest<IActionResult>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public string? Address { get; set; }
        public IFormFile? BannerPhoto { get; set; }
        public IFormFile? LogoPhoto { get; set; }
    }
}
