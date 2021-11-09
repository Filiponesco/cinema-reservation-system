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
    [Route("room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
   
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        private readonly IRoomService _roomService;

        [HttpPost]
        public ActionResult Create([FromBody] CreateRoomDto dto)
        {
            var id = _roomService.Create(dto);

            return Created($"/room/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> GetAll()
        {
            var roomDtos = _roomService.GetAll();

            return Ok(roomDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _roomService.Delete(id);

            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<RoomDto> Get([FromRoute] int id)
        {
            var room = _roomService.GetById(id);

            return Ok(room);
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRoomDto dto, [FromRoute] int id)
        {

            _roomService.Update(id, dto);

            return Ok();
        }

    }
}
