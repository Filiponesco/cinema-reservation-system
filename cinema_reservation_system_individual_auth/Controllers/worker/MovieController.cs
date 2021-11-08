using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.models.worker;
using cinema_reservation_system_individual_auth.Services.worker;
using Microsoft.AspNetCore.Mvc;
namespace cinema_reservation_system_individual_auth.Controllers.worker
{
    [Route("movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
   
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        private readonly IMovieService _movieService;

        [HttpPost]
        public ActionResult Create([FromBody] CreateMovieDto dto)
        {
            var id = _movieService.Create(dto);

            return Created($"/movie/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var moviesDtos = _movieService.GetAll();

            return Ok(moviesDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _movieService.Delete(id);

            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movie = _movieService.GetById(id);

            return Ok(movie);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateMovieDto dto, [FromRoute] int id)
        {

            _movieService.Update(id, dto);

            return Ok();
        }

    }
}
