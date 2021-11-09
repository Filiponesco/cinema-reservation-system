using System;
namespace cinema_reservation_system_individual_auth.models.worker
{
    public class UpdateSeanceDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
    }
}
