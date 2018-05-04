using FluentAssertions;
using Xunit;

namespace Roomeo.Reservation.Tests
{
    public class RoomTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void InitializeRequired()
            {
                var room = new Room("Pahiyas");
                room.Name.Should().Be("Pahiyas");
            }
        }
    }
}