namespace CMDKhakatonProject.Domain.Entities
{
    public class Table
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
