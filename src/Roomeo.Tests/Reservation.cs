using System;

namespace Roomeo.Tests
{
    public class Reservation
    {
        public Reservation(string title, string organizer, Schedule schedule)
        {
            Title = title;
            Organizer = organizer;
            Schedule = schedule;
        }

        public string Title { get; }
        public string Organizer { get; }
        public Schedule Schedule { get; }
    }
}
