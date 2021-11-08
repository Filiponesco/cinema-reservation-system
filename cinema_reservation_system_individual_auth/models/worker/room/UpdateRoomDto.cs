using System;
namespace cinema_reservation_system_individual_auth.models.worker
{
    public class UpdateRoomDto
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public int CleaningTimeInMinutes { get; set; }
    }
}
