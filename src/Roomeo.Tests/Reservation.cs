using System;

namespace Roomeo.Tests
{
    public class Reservation
    {
        public Reservation(string title, string organizer, Room room, Schedule schedule)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (string.IsNullOrEmpty(organizer))
            {
                throw new ArgumentNullException(nameof(organizer));
            }
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            Title = title;
            Organizer = organizer;
            Room = room;
            Schedule = schedule;
        }

        public string Title { get; }
        public string Organizer { get; }
        public Room Room { get; }
        public Schedule Schedule { get; }
    }
}
