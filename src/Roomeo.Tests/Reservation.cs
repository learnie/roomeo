using System;
using Xunit;
using FluentAssertions;

namespace Roomeo.Tests
{
    public class Reservation
    {
        public Reservation(string title, string organizer, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Organizer = organizer;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Title { get; }
        public string Organizer { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }

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
                    new DateTime(2021,1,1), 
                    new DateTime(2021,1,2));
                
                reservation.Title.Should().Be("Title");
                reservation.Organizer.Should().Be("Ked");
                reservation.StartDate.Should().Be(new DateTime(2021, 1, 1));
                reservation.EndDate.Should().Be(new DateTime(2021, 1, 2));
            }
        }
    }
}
