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
    public interface IWorkerService
    {
        WorkerDto GetById(int id);
        IEnumerable<WorkerDto> GetAll();
        int Create(CreateWorkerDto dto);
        void Delete(int id);

    }
    public class WorkerService : IWorkerService
    {

        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkerService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public WorkerService(CinemaDbContext dbContext, IMapper mapper, ILogger<WorkerService> logger, IAuthorizationService authorizationService, IUserContextService userContextService) {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(CreateWorkerDto dto)
        {
            var worker = _mapper.Map<User>(dto);

            _dbContext.Users.Add(worker);
            _dbContext.SaveChanges();

            return worker.Id;
        }

        public void Delete(int id)
        {
            var worker = _dbContext
             .Users
             .FirstOrDefault(r => r.Id == id);

            if (worker is null)
                throw new NotFoundException("Worker not found");

            _dbContext.Users.Remove(worker);
            _dbContext.SaveChanges();
        }

        public IEnumerable<WorkerDto> GetAll()
        {
            var workers = _dbContext
                .Users.Where(u =>
                    u.RoleId == 2)
                .ToList();

            var workersDtos = _mapper.Map<List<WorkerDto>>(workers);

            return workersDtos;
        }

        public WorkerDto GetById(int id)
        {
            var workers = _dbContext
                .Users.Where(u =>
                    u.RoleId == 2).Include(w => w.Role)
                .FirstOrDefault(r => r.Id == id);

            if (workers is null)
                throw new NotFoundException("Worker not found");

            var result = _mapper.Map<WorkerDto>(workers);
            return result;
        }
    }
}
