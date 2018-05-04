using System;
using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;

namespace Roomeo.Reservation.Tests
{
    public class ReservationServiceTests
    {
        public class CancelMethod_Should
        {
            [Fact]
            public void BeSuccessful()
            {
                var repo = new Mock<IReservationRepository>();
                repo
                    .Setup(r => r.Exists(123))
                    .Returns(true);

                var service = new ReservationService(repo.Object);
                service.Cancel(123);

                repo.Verify(r => r.Delete(It.Is<int>(roomId => roomId == 123)), Times.Once());
            }

            [Fact]
            public void NotBeSuccessful_WhenReservationDoesNotExist()
            {
                var repo = new Mock<IReservationRepository>();
                repo
                    .Setup(r => r.Exists(123))
                    .Returns(false);

                var service = new ReservationService(repo.Object);
                Action sut = () => service.Cancel(123);

                sut.Should().Throw<InvalidOperationException>();
            }
        }

        public class GetAllMethod_Should
        {
            [Fact]
            public void ReturnAllReservations()
            {
                var repo = new Mock<IReservationRepository>();
                repo
                    .Setup(r => r.GetAll(It.IsAny<DateTime>(), 123))
                    .Returns(new List<Reservation>() { new Reservation(new Employee("John Doe"), new Room("Pahiyas"), new Schedule(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2))) });

                var service = new ReservationService(repo.Object);
                var sut = service.GetAll(DateTime.Now, 123);
                sut.Should().HaveCount(1);
            }
        }
    }
}
