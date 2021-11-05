using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.Services.admin;
using Microsoft.AspNetCore.Mvc;

namespace cinema_reservation_system_individual_auth
{
    [Route("admin")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAdminAccountService _accountService;

        public AdminAccountController(IAdminAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterAdminDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);

        }
    }
}
