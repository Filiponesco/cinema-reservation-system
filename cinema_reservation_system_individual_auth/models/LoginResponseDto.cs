using System;
namespace cinema_reservation_system_individual_auth.models
{
    public class LoginResponseDto
    {

        public UserDto UserDto { get; set; }
        public string Token { get; set; }
        

    }
}
