using System;
using Xunit;
using Moq;
using FluentAssertions;

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
    }
}
