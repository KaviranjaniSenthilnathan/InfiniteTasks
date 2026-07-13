using Moq;
using Xunit;
using FluentAssertions;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Services.Implementations;
using EmployeeManagement.API.Model;

namespace EmployeeManagement.API.Tests.DepartmentTests
{
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentRepository> _repoMock;
        private readonly DepartmentService _service;

        public DepartmentServiceTests()
        {
            _repoMock = new Mock<IDepartmentRepository>();

            _service = new DepartmentService(_repoMock.Object);
        }

        [Fact]
        public async Task GetAllDepartments_ReturnsDepartments()
        {
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentID = 1,
                    DepartmentName = "HR"
                }
            };

            _repoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(departments);

            var result = await _service.GetAllAsync();

            result.Should().NotBeNull();
            result.Count().Should().Be(1);
        }
    }
}