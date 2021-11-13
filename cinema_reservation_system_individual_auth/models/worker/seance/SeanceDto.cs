using System;
namespace cinema_reservation_system_individual_auth.models.worker
{
    public class SeanceDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public MovieDto Movie { get; set; }
        public RoomDto Room { get; set; }
    }
}
