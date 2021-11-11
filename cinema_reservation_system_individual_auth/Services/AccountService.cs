using System;
using cinema_reservation_system_individual_auth.models;
using Microsoft.AspNetCore.Identity;

namespace cinema_reservation_system_individual_auth.Services.admin
{

    public interface IAccountService
    {
        LoginResponseDto GenerateJwt(LoginDto dto);

    }
    public class AccountService : IAccountService
    {
        private readonly CinemaDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        IJwtService _jwtService;

        public AccountService(CinemaDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _jwtService = jwtService;
        }

        public LoginResponseDto GenerateJwt(LoginDto dto)
        {
            return _jwtService.GenerateJwt(dto);
        }

    }
}
