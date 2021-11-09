using System;
using System.ComponentModel.DataAnnotations;

namespace cinema_reservation_system_individual_auth.models.worker
{
    public class CreateSeanceDto
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
