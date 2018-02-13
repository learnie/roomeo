using System;

namespace Roomeo.Tests
{
    public interface IReservationRepository
    {
        void Insert(Reservation reservation);
        Reservations GetByRoomAndSchedule(Guid id, Schedule schedule);
    }
}
