namespace CMDKhakatonProject.Domain.Entities
{
    public class DishOrder
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public Guid DishId { get; set; }
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
