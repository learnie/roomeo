using System;

namespace Roomeo.Core
{

    public class ReservationService : IReservationService
    {
        private IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            this._repository = repository;
        }

        public void Create(Reservation reservation)
        {
            var reservations =
                _repository.GetByRoomAndSchedule(reservation.Room.Id, reservation.Schedule);
            
            if (reservations.HasConflict(reservation))
            {
                throw new InvalidOperationException();
            }

            _repository.Insert(reservation);
        }
    }
}
