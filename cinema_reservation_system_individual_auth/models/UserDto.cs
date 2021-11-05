using System;
namespace cinema_reservation_system_individual_auth.models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
