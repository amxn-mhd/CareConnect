using CareConnect.Services.AuthApi.models.Dto;
using CareConnect.Services.AuthApi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CareConnect.Services.AuthApi.Service.IAuthService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CareConnect.Services.AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegistrationRequestDto registrationRequestDto)
            {
                var userId = await _authService.Register(registrationRequestDto);
                return Ok(new { UserId = userId });
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
            {
                var response = await _authService.Login(loginRequestDto);
                return Ok(response);
            }

            [HttpPost("assign-role")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> AssignRole(string email, string roleName)
            {
                var result = await _authService.AssignRole(email, roleName);
                return result ? Ok("Role assigned successfully.") : BadRequest("Failed to assign role.");
            }

            [HttpGet("users")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> GetUsers()
            {
                var users = await _authService.GetUsers();
                return Ok(users);
            }
        }
    }

