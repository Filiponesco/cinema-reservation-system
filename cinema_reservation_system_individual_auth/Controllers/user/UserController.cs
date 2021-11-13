using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.models;
using cinema_reservation_system_individual_auth.Services.admin;
using Microsoft.AspNetCore.Mvc;

namespace cinema_reservation_system_individual_auth
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody]RegisterUserDto dto)
        {
            var id = _userService.Create(dto);

            return Ok();

        }
    }
}
