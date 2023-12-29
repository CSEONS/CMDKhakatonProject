using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.User
{
    public class DeleteDishFromBasketRequest : IRequest<IActionResult>
    {
        public string OrderId { get; set; }
        [JsonIgnore] public ClaimsPrincipal? User;
    }
}
