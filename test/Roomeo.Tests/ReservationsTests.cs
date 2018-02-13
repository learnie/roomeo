using System;
using FluentAssertions;
using Xunit;
using System.Linq;
using Roomeo.Core;

namespace Roomeo.Tests
{
    public class ReservationsTests
    {
        public class Add_Should
        {
            [Fact]
            public void AppendReservation()
            {
                var reservations = new Reservations();
                
                reservations.Add(new Reservation("Title",
                    "Ked",
                    new Room(Guid.NewGuid(), "Pahiyas", "16"),
                    new Schedule(
                        new DateTime(2021,1,1), 
                        new DateTime(2021,1,2))
                    ));
                
                reservations
                    .First()
                    .Title.Should().Be("Title");
            }
        }

        public class HasConflict_Should
        {
            [Fact]
            public void ReturnTrue()
            {
                var reservation = new Reservation("Title",
                    "Ked",
                    new Room(Guid.NewGuid(), "Pahiyas", "16"),
                    new Schedule(
                        new DateTime(2021,1,1), 
                        new DateTime(2021,1,2))
                    );

                var reservations = new Reservations();
                reservations.Add(reservation);

                reservations
                    .HasConflict(reservation)
                    .Should()
                    .BeTrue();
            }
        }
    }
}
