using System;
using System.ComponentModel.DataAnnotations;

namespace cinema_reservation_system_individual_auth.models.worker
{
    public class CreateRoomDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        public int CleaningTimeInMinutes { get; set; }
    }
}
