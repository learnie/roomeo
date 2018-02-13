using System;

namespace Roomeo.Api
{
    public class CreateReservationRequest
    {
        public string Title { get; set; }
        public string Organizer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}