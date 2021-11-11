using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinema_reservation_system_individual_auth.entities;
using cinema_reservation_system_individual_auth.Exceptions;
using cinema_reservation_system_individual_auth.models.worker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cinema_reservation_system_individual_auth.Services.worker
{
    public interface IReserveService
    {
        ReserveDto GetById(int id);
        IEnumerable<ReserveDto> GetAll();
        int Create(CreateReserveDto dto);
        void Delete(int id);
    }
    [Authorize]
    public class ReserveService : IReserveService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public ReserveService(CinemaDbContext dbContext, IMapper mapper, ILogger<RoomService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        // TODO authorize
        public int Create(CreateReserveDto dto)
        {
            var reserve = new Reservation()
            {
                UserId = (int)_userContextService.GetUserId,
                SeanceId = dto.SeanceId,
                Count = dto.Count,

            };

            var seance = _dbContext.Seances.Include(s => s.Room).FirstOrDefault(s => s.Id == dto.SeanceId);

            if (seance == null)
            {
                throw new NotFoundException("Seance not found");
            }

            _dbContext.Reservations.Add(reserve);
            _dbContext.SaveChanges();

            return reserve.Id;
        }
        // TODO authorize
        public void Delete(int id)
        {
            var Reserve = _dbContext
             .Reservations
             .FirstOrDefault(r => r.Id == id);

            if (Reserve is null)
                throw new NotFoundException("Reserve not found");

            _dbContext.Reservations.Remove(Reserve);
            _dbContext.SaveChanges();
        }

        // TODO authorize
        public IEnumerable<ReserveDto> GetAll()
        {
            var Reserves = _dbContext
                .Reservations.Where(r => r.UserId == _userContextService.GetUserId)
                .ToList();

            var ReservesDtos = _mapper.Map<List<ReserveDto>>(Reserves);

            return ReservesDtos;
        }

        // TODO authorize
        public ReserveDto GetById(int id)
        {

            var Reserves = _dbContext.Reservations
                .FirstOrDefault(r => r.Id == id && r.UserId == _userContextService.GetUserId);

            if (Reserves is null)
                throw new NotFoundException("Reserve not found");

            var result = _mapper.Map<ReserveDto>(Reserves);
            return result;
        }

    }
}
