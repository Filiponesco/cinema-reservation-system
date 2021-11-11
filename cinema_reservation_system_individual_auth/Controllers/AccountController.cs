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
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            LoginResponseDto response = _accountService.GenerateJwt(dto);
            return Ok(response);

        }
    }
}
