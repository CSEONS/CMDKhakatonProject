using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.User
{
    public class MeRequest : IRequest<IActionResult>
    {
        [JsonIgnore] public ClaimsPrincipal? User { get; set; }
    }
}
