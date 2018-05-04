using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomeo.Reservation.Contracts;

namespace Roomeo.Reservation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _service;
        
        public ReservationsController(IReservationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET api/reservations
        [HttpGet]
        public ActionResult<IEnumerable<Contracts.ReservationModel>> Get([FromQuery]DateTime date, [FromQuery]int roomId)
        {
            IEnumerable<Reservation> reservation = _service.GetAll(date, roomId);
            return Ok(reservation.Select(r => new ReservationModel() { Id = r.Id }));
        }

        // POST api/reservations
        [HttpPost]
        public IActionResult Make([FromBody]Contracts.ReservationModel reservation)
        {
            return Ok();
        }

        // DELETE api/reservations/5
        [HttpDelete("{roomId}")]
        public IActionResult Cancel(int roomId)
        {
            _service.Cancel(roomId);
            return NoContent();
        }
    }
}
