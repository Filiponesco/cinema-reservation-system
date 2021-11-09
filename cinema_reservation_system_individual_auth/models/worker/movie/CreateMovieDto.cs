using System;
using System.ComponentModel.DataAnnotations;

namespace cinema_reservation_system_individual_auth.models.worker
{
    public class CreateMovieDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DurationInMinutes { get; set; }
    }
}
