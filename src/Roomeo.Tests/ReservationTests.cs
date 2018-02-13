using System;
using Xunit;
using FluentAssertions;

namespace Roomeo.Tests
{
    public class ReservationTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void Accept_Required()
            {
                var reservation = new Reservation(
                    "Title",
                    "Ked",
                    new Room(
                        Guid.Empty,
                        "Pahiyas",
                        "16"
                    ),
                    new Schedule(
                        new DateTime(2021,1,1), 
                        new DateTime(2021,1,2)
                    ));
                
                reservation.Title.Should().Be("Title");
                reservation.Organizer.Should().Be("Ked");
                reservation.Schedule.Should().Be(new Schedule(
                    new DateTime(2021,1,1), 
                    new DateTime(2021,1,2)));
                reservation.Room.Id.Should().Be(Guid.Empty);
            }
        }
    }
}
