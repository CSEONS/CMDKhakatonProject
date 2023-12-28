using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.User
{
    public class AddDishToBasketRequest : IRequest<IActionResult>
    {
        public Guid DishId { get; set; }
        public int Amont {  get; set; }
        public string? Description { get; set; }
        #region Attribute
        [JsonIgnore]
        #endregion
        public ClaimsPrincipal? User;
    }
}

