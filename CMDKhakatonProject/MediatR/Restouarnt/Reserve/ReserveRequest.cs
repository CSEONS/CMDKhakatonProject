using CMDKhakatonProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class ReserveRequest : IRequest<IActionResult>
    {
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
        public Table Table { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public int PeopleAmount { get; set; }
        [JsonIgnore] public ClaimsPrincipal? User;
    }
}
