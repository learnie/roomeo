using System;

namespace Roomeo.Reservation
{
    public interface IReservationService
    {
        void Cancel(int roomId);
    }
}
