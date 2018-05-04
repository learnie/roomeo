using System;
using FluentAssertions;
using Xunit;

namespace Roomeo.Reservation.Tests
{
    public class ScheduleTests
    {
        public class Equals_Should
        {
            [Fact]
            public void MatchByValue()
            {
                var schedule = new Schedule(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2));
                schedule.Should().Be(new Schedule(new DateTime(2018, 1, 1), new DateTime(2018, 1, 2)));
            }
        }
    }
}