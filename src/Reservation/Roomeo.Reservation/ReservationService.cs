using System;
using System.Collections.Generic;

namespace Roomeo.Reservation
{
    public class ReservationService : IReservationService
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

        public IEnumerable<Reservation> GetAll(DateTime date, int roomId)
        {
            return _repository.GetAll(date, roomId);
        }
    }
}