using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinema_reservation_system_individual_auth.Exceptions;
using cinema_reservation_system_individual_auth.Helpers;
using cinema_reservation_system_individual_auth.models;
using cinema_reservation_system_individual_auth.models.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cinema_reservation_system_individual_auth.Services.admin
{
    public interface IUserService
    {
        int Create(RegisterUserDto dto);
    }
    public class UserService : IUserService
    {

        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkerService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public UserService(CinemaDbContext dbContext, IMapper mapper, ILogger<WorkerService> logger, IAuthorizationService authorizationService, IUserContextService userContextService) {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(RegisterUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

    }
}
