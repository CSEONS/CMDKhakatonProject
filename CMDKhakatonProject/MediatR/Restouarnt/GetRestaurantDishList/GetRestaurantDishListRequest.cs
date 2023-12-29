using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace CMDKhakatonProject.MediatR.Restouarnt
{
    public class GetRestaurantDishListRequest : IRequest<IActionResult>
    {
        [JsonIgnore] public string RestaurantId { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public string?[] Tgas { get; set; }
        public double? MaxPrice { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxRating { get; set; }
        public double? MinRating { get; set; }
    }
}
