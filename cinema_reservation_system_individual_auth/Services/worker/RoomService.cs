using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinema_reservation_system_individual_auth.entities;
using cinema_reservation_system_individual_auth.Exceptions;
using cinema_reservation_system_individual_auth.models.worker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace cinema_reservation_system_individual_auth.Services.worker
{
    public interface IRoomService
    {
        RoomDto GetById(int id);
        IEnumerable<RoomDto> GetAll();
        int Create(CreateRoomDto dto);
        void Delete(int id);
        void Update(int id, UpdateRoomDto dto);
    }
    public class RoomService : IRoomService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public RoomService(CinemaDbContext dbContext, IMapper mapper, ILogger<RoomService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }


        public int Create(CreateRoomDto dto)
        {
            var room = _mapper.Map<Room>(dto);

            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();

            return room.Id;
        }

        public void Delete(int id)
        {
            var room = _dbContext
             .Rooms
             .FirstOrDefault(r => r.Id == id);

            if (room is null)
                throw new NotFoundException("Room not found");

            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
        }

        public IEnumerable<RoomDto> GetAll()
        {
            var rooms = _dbContext
                .Rooms
                .ToList();

            var roomsDtos = _mapper.Map<List<RoomDto>>(rooms);

            return roomsDtos;
        }

        public RoomDto GetById(int id)
        {
            var rooms = _dbContext.Rooms
                .FirstOrDefault(r => r.Id == id);

            if (rooms is null)
                throw new NotFoundException("Room not found");

            var result = _mapper.Map<RoomDto>(rooms);
            return result;
        }

        public void Update(int id, UpdateRoomDto dto)
        {
            var room = _dbContext
              .Rooms
              .FirstOrDefault(r => r.Id == id);

            if (room is null)
                throw new NotFoundException("Room not found");

            room.Name = dto.Name;
            room.SeatsCount = dto.SeatsCount;
            room.CleaningTimeInMinutes = dto.CleaningTimeInMinutes;

            _dbContext.SaveChanges();
        }
    }
}
