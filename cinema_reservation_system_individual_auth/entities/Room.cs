using System;
namespace cinema_reservation_system_individual_auth.entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public int CleaningTimeInMinutes { get; set; }
    }
}
