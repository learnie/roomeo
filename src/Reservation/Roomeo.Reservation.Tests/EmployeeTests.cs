using FluentAssertions;
using Xunit;

namespace Roomeo.Reservation.Tests
{
    public class EmployeeTests
    {
        public class Constructor_Should
        {
            [Fact]
            public void InitializeRequired()
            {
                var employee = new Employee("John Doe");
                employee.Name.Should().Be("John Doe");
            }

            [Fact]
            public void InitializeId()
            {
                var employee = new Employee(123, "John Doe");
                employee.Id.Should().Be(123);
            }
        }
    }
}