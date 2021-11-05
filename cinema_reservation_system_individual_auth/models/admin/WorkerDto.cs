using System;
namespace cinema_reservation_system_individual_auth.models.admin
{
    public class WorkerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
