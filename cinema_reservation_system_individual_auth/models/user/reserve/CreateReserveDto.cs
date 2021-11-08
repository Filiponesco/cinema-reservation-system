using System;
using System.ComponentModel.DataAnnotations;

namespace cinema_reservation_system_individual_auth.models.worker
{
    public class CreateReserveDto
    {
        [Required]
        public int SeanceId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
