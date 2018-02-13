using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Roomeo.Tests
{
    public class RoomsControllerTests
    {
        public class Create_Should
        {
            [Fact]
            public void CreateReservation()
            {
                var service = new Mock<IReservationService>();

                var controller = new RoomsController(service.Object);
                var request = new CreateReservationRequest();

                var result = controller.Create(request);

                result
                    .Should()
                    .Be("200");
            }

            [Fact]
            public void Return500_WhenError()
            {
                var service = new Mock<IReservationService>();

                service
                    .Setup(s => s.Create(It.IsAny<Reservation>()))
                    .Throws(new Exception());

                var controller = new RoomsController(service.Object);
                var request = new CreateReservationRequest();

                var result = controller.Create(request);

                result
                    .Should()
                    .Be("500");
            }
        }
    }
}
