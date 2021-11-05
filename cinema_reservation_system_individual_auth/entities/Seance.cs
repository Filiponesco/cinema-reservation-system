using System;
namespace cinema_reservation_system_individual_auth.entities
{
    public class Seance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public virtual Room Room { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
