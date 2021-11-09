using System;
using Microsoft.AspNetCore.Identity;

namespace cinema_reservation_system_individual_auth.Services.admin
{

    public interface IAdminAccountService
    {
        void RegisterUser(RegisterAdminDto dto);
        string GenerateJwt(LoginDto dto);

    }
    public class AdminAccountService : IAdminAccountService
    {
        private readonly CinemaDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        IJwtService _jwtService;

        public AdminAccountService(CinemaDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            _jwtService = jwtService;
        }

        public string GenerateJwt(LoginDto dto)
        {
            return _jwtService.GenerateJwt(dto);
        }

        public void RegisterUser(RegisterAdminDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                RoleId = 3
            };
            var caesarPassword = CaesarCipher.Encipher(dto.Password, Consts.CeasarCipherKey);
            newUser.Password = caesarPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
