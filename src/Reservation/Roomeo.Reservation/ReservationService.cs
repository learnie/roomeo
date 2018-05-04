using System;

namespace Roomeo.Reservation
{
    public class ReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Cancel(int roomId)
        {
            if (!_repository.Exists(roomId))
            {
                throw new InvalidOperationException();
            }
            
            _repository.Delete(roomId);
        }
    }
}