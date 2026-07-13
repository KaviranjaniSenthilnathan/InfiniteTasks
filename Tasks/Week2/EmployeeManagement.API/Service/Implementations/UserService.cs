using EmployeeManagement.API.DTOs.Auth;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Repository.Interfaces;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository,
                           IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUserNameAsync(dto.UserName);

            if (user == null)
                return null;

            if (user.Password != dto.Password)
                return null;

            return _jwtService.GenerateToken(user);
        }
    }
}