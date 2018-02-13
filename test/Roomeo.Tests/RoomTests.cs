using System;
using Xunit;
using FluentAssertions;
using Roomeo.Core;

namespace Roomeo.Tests
{
    public class RoomTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void Accept_Required()
            {
                var room = new Room(Guid.Empty, "Pahiyas", "16");

                room.Id.Should().Be(Guid.Empty);
                room.Active.Should().BeTrue();
            }

            [Fact]
            public void Accept_Values()
            {
                Guid guid = Guid.NewGuid();
                var room = new Room(
                    guid,
                    "Pahiyas",
                    "16"
                );

                room.Id.Should().Be(guid);
                room.Name.Should().Be("Pahiyas");
                room.Floor.Should().Be("16");
            }
        }
    }
}
