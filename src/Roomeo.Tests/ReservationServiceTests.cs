using System;
using Moq;
using FluentAssertions;
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

                repository
                    .Setup(r => r.GetByRoomAndSchedule(It.IsAny<Guid>(), It.IsAny<Schedule>()))
                    .Returns(new Reservations());

                var service = new ReservationService(repository.Object);

                service.Create(new Reservation("Title",
                    "Ked",
                    new Room(Guid.NewGuid(), "Pahiyas", "16"),
                    new Schedule(
                        new DateTime(2021,1,1), 
                        new DateTime(2021,1,2))
                    ));

                repository
                    .Verify(r => r.Insert(It.IsAny<Reservation>()), Times.Once());
            }

            [Fact]
            public void ThrowException_WhenRoomIsOccupied()
            {
                var room = new Room(Guid.NewGuid(), "Pahiyas", "16");
                var schedule = new Schedule(
                        new DateTime(2021,1,1), 
                        new DateTime(2021,1,2));

                var repository = new Mock<IReservationRepository>();
                repository
                    .Setup(r => r.GetByRoomAndSchedule(It.IsAny<Guid>(), It.IsAny<Schedule>()))
                    .Returns(new Reservations());
                    

                var reservations = new Reservations();
                reservations.Add(new Reservation("Title", "Ked", room, schedule));

                repository
                    .Setup(r => r.GetByRoomAndSchedule(room.Id, schedule))
                    .Returns(reservations);

                var service = new ReservationService(repository.Object);

                Action sut = () => service.Create(new Reservation("Title",
                    "Ked",
                    room,
                    schedule));

                sut.Should().Throw<InvalidOperationException>();
            }
        }
    }
}
