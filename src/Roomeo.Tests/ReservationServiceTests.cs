using System;
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

                service.Create(new Reservation("Title",
                    "Ked",
                    new DateTime(2021,1,1), 
                    new DateTime(2021,1,2)));

                repository
                    .Verify(r => r.Insert(It.IsAny<Reservation>()), Times.Once());
            }
        }
    }
}
