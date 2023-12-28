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
        public string Type { get; set; }
    }
}
