using System;

namespace Roomeo.Core
{
    public interface IReservationRepository
    {
        void Insert(Reservation reservation);
        Reservations GetByRoomAndSchedule(Guid id, Schedule schedule);
    }
}
