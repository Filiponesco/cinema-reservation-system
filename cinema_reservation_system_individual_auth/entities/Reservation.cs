using System;
namespace cinema_reservation_system_individual_auth.entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int SeanceId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public virtual Seance Seance { get; set; }
        public virtual User User { get; set; }
    }
}
