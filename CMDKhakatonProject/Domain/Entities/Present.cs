namespace CMDKhakatonProject.Domain.Entities
{
    public class Present
    {
        public string Id { get; set; }
        public string ReciverId { get; set; }
        public AppUser Reciver { get; set; }
        public string DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
