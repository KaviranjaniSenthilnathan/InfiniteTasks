using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.DTOs.Auth;
using EmployeeManagement.API.Services.Interfaces;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.RegisterAsync(dto);
            return Ok(new
            {
                Message = "User Registered Successfully"
            });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _userService.LoginAsync(dto);
            if (token == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid Username or Password"
                });
            }
            return Ok(new
            {
                Token = token
            });
        }
    }
}