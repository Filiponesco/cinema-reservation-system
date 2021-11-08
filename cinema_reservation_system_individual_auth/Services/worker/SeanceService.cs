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
    public interface ISeanceService
    {
        SeanceDto GetById(int id);
        IEnumerable<SeanceDto> GetAll();
        int Create(CreateSeanceDto dto);
        void Delete(int id);
        void Update(UpdateSeanceDto dto);
        int GetCountById(int id);
    }
    public class SeanceService : ISeanceService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<SeanceService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public SeanceService(CinemaDbContext dbContext, IMapper mapper, ILogger<SeanceService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }


        public int Create(CreateSeanceDto dto)
        {
            var Seance = _mapper.Map<Seance>(dto);

            _dbContext.Add(Seance);
            _dbContext.SaveChanges();

            return Seance.Id;
        }

        public void Delete(int id)
        {
            var Seance = _dbContext
             .Seances
             .FirstOrDefault(r => r.Id == id);

            if (Seance is null)
                throw new NotFoundException("Seance not found");

            _dbContext.Seances.Remove(Seance);
            _dbContext.SaveChanges();
        }

        public IEnumerable<SeanceDto> GetAll()
        {
            var Seances = _dbContext
                .Seances
                .ToList();

            var SeancesDtos = _mapper.Map<List<SeanceDto>>(Seances);

            return SeancesDtos;
        }

        public SeanceDto GetById(int id)
        {
            var Seances = _dbContext.Seances
                .FirstOrDefault(r => r.Id == id);

            if (Seances is null)
                throw new NotFoundException("Seance not found");

            var result = _mapper.Map<SeanceDto>(Seances);
            return result;
        }

        public int GetCountById(int id)
        {
            return 7; // TODO zwracać liczbę zarezerwowanych miejsc
        }

        public void Update(UpdateSeanceDto dto)
        {

            var Seance = _dbContext
              .Seances
              .FirstOrDefault(r => r.Id == dto.Id);

            if (Seance is null)
                throw new NotFoundException("Seance not found");

            Seance.MovieId = dto.MovieId;
            Seance.RoomId = dto.RoomId;
            Seance.DateTime = dto.DateTime;

            _dbContext.SaveChanges();
        }
    }
}
