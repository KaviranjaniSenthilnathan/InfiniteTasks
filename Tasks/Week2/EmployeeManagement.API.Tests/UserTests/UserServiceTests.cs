using EmployeeManagement.API.DTOs.Auth;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Services.Implementations;
using EmployeeManagement.API.Services.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeManagement.API.Tests.UserTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepo;
        private readonly Mock<IJwtService> _jwtService;
        private readonly UserService _service;

        public UserServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();
            _jwtService = new Mock<IJwtService>();

            _service = new UserService(
                _userRepo.Object,
                _jwtService.Object);
        }

        [Fact]
        public async Task Login_ReturnsToken_WhenCredentialsAreValid()
        {
            var user = new User
            {
                UserName = "Athul",
                Password = "1234",
                Role = "HR"
            };

            _userRepo.Setup(x =>
                    x.GetByUserNameAsync("Athul"))
                .ReturnsAsync(user);

            _jwtService.Setup(x =>
                    x.GenerateToken(user))
                .Returns("fake-token");

            var result = await _service.LoginAsync(
                new LoginDto
                {
                    UserName = "Athul",
                    Password = "1234"
                });

            result.Should().Be("fake-token");
        }

        [Fact]
        public async Task Login_ReturnsNull_WhenUserNotFound()
        {
            _userRepo.Setup(x =>
                x.GetByUserNameAsync("Unknown"))
                .ReturnsAsync((User)null);

            var result = await _service.LoginAsync(
                new LoginDto
                {
                    UserName = "Unknown",
                    Password = "1234"
                });

            result.Should().BeNull();
        }
    }
}