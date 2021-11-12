using System;
using System.Collections.Generic;
using cinema_reservation_system_individual_auth.models;
using cinema_reservation_system_individual_auth.models.admin;
using cinema_reservation_system_individual_auth.Services.admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cinema_reservation_system_individual_auth.Controllers.admin
{
    [Route("worker")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost]
        public ActionResult CreateWorker([FromBody] CreateWorkerDto dto)
        {
            var id = _workerService.Create(dto);

            return Created($"/worker/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var restaurantsDtos = _workerService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _workerService.Delete(id);

            return NoContent();
        }



        [HttpGet("{id}")]
        public ActionResult<WorkerDto> Get([FromRoute] int id)
        {
            WorkerDto worker = _workerService.GetById(id);

            return Ok(worker);
        }

    }
}
