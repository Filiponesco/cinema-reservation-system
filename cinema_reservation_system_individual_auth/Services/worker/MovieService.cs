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
    public interface IMovieService
    {
        MovieDto GetById(int id);
        IEnumerable<MovieDto> GetAll();
        int Create(CreateMovieDto dto);
        void Delete(int id);
        void Update(int id, UpdateMovieDto dto);
    }
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public MovieService(CinemaDbContext dbContext, IMapper mapper, ILogger<RoomService> logger, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }


        public int Create(CreateMovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return movie.Id;
        }

        public void Delete(int id)
        {
            var movie = _dbContext
             .Movies
             .FirstOrDefault(r => r.Id == id);

            if (movie is null)
                throw new NotFoundException("Movie not found");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _dbContext
                .Movies
                .ToList();

            var moviesDtos = _mapper.Map<List<MovieDto>>(movies);

            return moviesDtos;
        }

        public MovieDto GetById(int id)
        {
            var movies = _dbContext.Movies
                .FirstOrDefault(r => r.Id == id);

            if (movies is null)
                throw new NotFoundException("Movie not found");

            var result = _mapper.Map<MovieDto>(movies);
            return result;
        }

        public void Update(int id, UpdateMovieDto dto)
        {
            var movie = _dbContext
              .Movies
              .FirstOrDefault(r => r.Id == id);

            if (movie is null)
                throw new NotFoundException("Movie not found");

            movie.Name = dto.Name;
            movie.DurationInMinutes = dto.DurationInMinutes;

            _dbContext.SaveChanges();
        }
    }
}
