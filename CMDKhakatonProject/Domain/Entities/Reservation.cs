namespace CMDKhakatonProject.Domain.Entities
{
    public class Reservation
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public Table Table { get; set; }
        public string ReserverId { get; set; }
        public AppUser Reserver { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
