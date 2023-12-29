namespace CMDKhakatonProject.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public Table Table { get; set; }
        public Guid ReserverId { get; set; }
        public AppUser Reserver { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
