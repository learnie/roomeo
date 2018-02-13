using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Roomeo.Tests
{
    public class ReservationServiceTests 
    {
        public class Create_Should
        {
            [Fact]
            public void Save_Reservation()
            {
                var repository = new Mock<IReservationRepository>();
                var service = new ReservationService(repository.Object);

                service.Create(new Reservation());

                repository
                    .Verify(r => r.Insert(It.IsAny<Reservation>()), Times.Once());
            }
        }
    }

    public class Reservation
    {
    }

    public interface IReservationRepository
    {
        void Insert(Reservation reservation);
    }

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
