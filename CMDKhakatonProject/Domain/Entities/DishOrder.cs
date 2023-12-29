namespace CMDKhakatonProject.Domain.Entities
{
    public class DishOrder
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public string DishId { get; set; }
        public Dish Dish { get; set; }
        public int Amount { get; set; }
        public DishOrderStatus Status { get; set; }
        public string? Description { get; set; }
    }

    public enum DishOrderStatus
    {
        Basket,
        Cooking,
        Complete,
        Archive,
    }
}
