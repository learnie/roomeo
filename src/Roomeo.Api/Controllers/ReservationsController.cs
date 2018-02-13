using System;
using Microsoft.AspNetCore.Mvc;
using Roomeo.Core;

namespace Roomeo.Api.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _service;

        public ReservationsController(IReservationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult Create(CreateReservationRequest request)
        {
            try
            {
                _service.Create(
                    new Reservation(
                        request.Title,
                        request.Organizer,
                        new Room(Guid.NewGuid() ,"Pahiyas", "16"),
                        new Schedule(
                            request.StartDate,
                            request.EndDate
                        )
                    ));
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }


}
