namespace Roomeo.Tests
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
            _repository.Insert(reservation);
        }
    }
}
