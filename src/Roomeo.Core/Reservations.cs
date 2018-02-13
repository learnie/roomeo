using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Roomeo.Core
{
    public class Reservations : IEnumerable<Reservation>
    {
        private readonly List<Reservation> _reservations;

        public Reservations()
        {
            _reservations = new List<Reservation>();
        }

        public IEnumerator<Reservation> GetEnumerator()
        {
            return _reservations.GetEnumerator();
        }

        public void Add(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool HasConflict(Reservation reservation)
        {
            return _reservations.Any(r => 
                r.Room.Id == reservation.Room.Id && 
                r.Schedule.IsOverlap(reservation.Schedule));
        }
    }
}
