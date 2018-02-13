using System;

namespace Roomeo.Tests
{
    public class RoomsController
    {
        private readonly IReservationService _service;

        public RoomsController(IReservationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string Create(CreateReservationRequest request)
        {
            try
            {
                _service.Create(new Reservation());
            }
            catch
            {
                return "500";
            }
            return "200";
        }
    }


}
