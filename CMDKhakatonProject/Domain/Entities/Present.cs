namespace CMDKhakatonProject.Domain.Entities
{
    public class Present
    {
        public Guid Id { get; set; }
        public Guid ReciverId { get; set; }
        public AppUser Reciver { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
