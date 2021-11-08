using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cinema_reservation_system_individual_auth.models.worker;
using cinema_reservation_system_individual_auth.Services.worker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace cinema_reservation_system_individual_auth.Controllers.worker
{
    [Route("Reserve")]
    [ApiController]
    [Authorize]
    public class ReserveController : ControllerBase
    {
   
        public ReserveController(IReserveService ReserveService)
        {
            _ReserveService = ReserveService;
        }
        private readonly IReserveService _ReserveService;

        [HttpPost]
        public ActionResult Create([FromBody] CreateReserveDto dto)
        {
            var id = _ReserveService.Create(dto);

            return Created($"/Reserve/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReserveDto>> GetAll()
        {
            var ReservesDtos = _ReserveService.GetAll();

            return Ok(ReservesDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _ReserveService.Delete(id);

            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<ReserveDto> Get([FromRoute] int id)
        {

            var Reserve = _ReserveService.GetById(id);

            return Ok(Reserve);
        }

    }
}
