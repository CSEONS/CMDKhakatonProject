namespace CMDKhakatonProject.Domain.Entities
{
    public class Table
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
