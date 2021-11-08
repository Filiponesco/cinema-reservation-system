using System;
namespace cinema_reservation_system_individual_auth.models.worker
{
    public class ReserveDto
    {
        public int Id { get; set; }
        public int SeanceId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }
    }
}
