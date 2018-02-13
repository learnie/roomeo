using System;
using FluentAssertions;
using Xunit;

namespace Roomeo.Tests
{
    public class ScheduleTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void Accept_Required()
            {
                var schedule = new Schedule(
                    new DateTime(2021,1,1), 
                    new DateTime(2021,1,2)
                );

                schedule.Begin.Should().Be(new DateTime(2021, 1,1));
                schedule.End.Should().Be(new DateTime(2021, 1,2));
            }

            [Fact]
            public void ThrowException_WhenBeginGreaterThanEnd()
            {
                Action sut = () => new Schedule(
                    new DateTime(2021,1,3), 
                    new DateTime(2021,1,2)
                );

                sut.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}