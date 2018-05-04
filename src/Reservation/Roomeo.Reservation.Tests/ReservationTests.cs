using Xunit;
using FluentAssertions;
using System;

namespace Roomeo.Reservation.Tests
{
    public class ReservationTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void InitializeRequired()
            {
                var reservation = new Reservation(new Employee("John Doe"), new Room("Pahiyas"), new Schedule(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2)));
                reservation.Employee.Should().NotBeNull();
                reservation.Room.Should().NotBeNull();
                reservation.Schedule.Should().NotBeNull();
            }

            [Fact]
            public void InitializeId()
            {
                var reservation = new Reservation(123, new Employee("John Doe"), new Room("Pahiyas"), new Schedule(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2)));
                reservation.Id.Should().Be(123);
            }
        }
    }
}