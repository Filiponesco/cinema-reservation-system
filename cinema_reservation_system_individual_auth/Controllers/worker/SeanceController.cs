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
    [Route("seance")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
   
        public SeanceController(ISeanceService seanceService)
        {
            _seanceService = seanceService;
        }
        private readonly ISeanceService _seanceService;

        [HttpPost]
        public ActionResult Create([FromBody] CreateSeanceDto dto)
        {
            var id = _seanceService.Create(dto);

            return Created($"/seance/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeanceDto>> GetAll()
        {
            var seanceDtos = _seanceService.GetAll();

            return Ok(seanceDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _seanceService.Delete(id);

            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<SeanceDto> Get([FromRoute] int id)
        {
            var seance = _seanceService.GetById(id);

            return Ok(seance);
        }
        [HttpPut]
        public ActionResult Update([FromBody] UpdateSeanceDto dto)
        {

            _seanceService.Update(dto);

            return Ok();
        }
        [HttpGet("{id}/count")]
        public ActionResult<int> GetCount([FromRoute] int id)
        {
            var seance = _seanceService.GetCountById(id);

            return Ok(seance);
        }

    }
}
