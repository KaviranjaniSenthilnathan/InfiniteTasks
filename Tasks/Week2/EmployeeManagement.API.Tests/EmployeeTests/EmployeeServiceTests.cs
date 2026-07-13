using Moq;
using Xunit;
using FluentAssertions;
using EmployeeManagement.API.Services.Implementations;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Tests.EmployeeTests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repoMock;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _repoMock = new Mock<IEmployeeRepository>();

            _service = new EmployeeService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllEmployees_ReturnsEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "Athul"
                }
            };

            _repoMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(employees);

            var result = await _service.GetAllAsync();

            result.Should().NotBeNull();
            result.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsEmployee()
        {
            var employee = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Athul"
            };

            _repoMock.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(employee);

            var result = await _service.GetByIdAsync(1);

            result.Should().NotBeNull();
        }
    }
}