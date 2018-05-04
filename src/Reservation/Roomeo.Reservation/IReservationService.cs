using System;
using System.Collections.Generic;

namespace Roomeo.Reservation
{
    public interface IReservationService
    {
        void Cancel(int roomId);
        IEnumerable<Reservation> GetAll(DateTime date, int roomId);
    }
}
