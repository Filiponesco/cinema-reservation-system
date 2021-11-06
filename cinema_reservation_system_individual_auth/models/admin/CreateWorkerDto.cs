using System;
using System.ComponentModel.DataAnnotations;

namespace cinema_reservation_system_individual_auth.models.admin
{
    public class CreateWorkerDto
    {
        [Required]
        public string Email { get; set; }
    }
}
