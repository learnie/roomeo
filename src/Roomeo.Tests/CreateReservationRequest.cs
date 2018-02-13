using System;

namespace Roomeo.Tests
{
    public class CreateReservationRequest
    {
        public string Title { get; internal set; }
        public string Organizer { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
    }


}
