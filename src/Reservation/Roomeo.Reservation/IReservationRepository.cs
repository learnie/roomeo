using System;
using System.Collections.Generic;

namespace Roomeo.Reservation
{
    public interface IReservationRepository
    {
        void Delete(int roomId);
        bool Exists(int roomId);
        IEnumerable<Reservation> GetAll(DateTime date, int roomId);
    }
}