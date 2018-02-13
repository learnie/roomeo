using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Roomeo.Api;
using Roomeo.Api.Controllers;
using Roomeo.Core;
using Xunit;

namespace Roomeo.Tests
{
    public class ReservationControllerTests
    {
        public class Create_Should
        {
            [Fact]
            public void CreateReservation()
            {
                var service = new Mock<IReservationService>();

                var controller = new ReservationsController(service.Object);
                var request = new CreateReservationRequest()
                {
                    Title = "Title",
                    Organizer = "Ked",
                    StartDate = new DateTime(2021, 1, 1),
                    EndDate = new DateTime(2021, 1, 2)
                };

                var result = controller.Create(request) as StatusCodeResult;

                result
                    .StatusCode
                    .Should()
                    .Be(200);
            }

            [Fact]
            public void Return500_WhenError()
            {
                var service = new Mock<IReservationService>();

                service
                    .Setup(s => s.Create(It.IsAny<Reservation>()))
                    .Throws(new Exception());

                var controller = new ReservationsController(service.Object);
                var request = new CreateReservationRequest();

                var result = controller.Create(request) as StatusCodeResult;

                result
                    .StatusCode
                    .Should()
                    .Be(500);
            }
        }
    }
}
