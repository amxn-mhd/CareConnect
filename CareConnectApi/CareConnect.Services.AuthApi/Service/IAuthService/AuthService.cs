using CareConnect.Services.AuthApi.Data;
using CareConnect.Services.AuthApi.models.Dto;
using CareConnect.Services.AuthApi.models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CareConnect.Services.AuthApi.Service.IAuthService
{
   
        public class AuthService : IAuthService
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IConfiguration _configuration;

            public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _configuration = configuration;
            }

            public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
            {
                var user = new ApplicationUser
                {
                    UserName = registrationRequestDto.UserName,
                    Email = registrationRequestDto.Email,
                    PhoneNumber = registrationRequestDto.PhoneNumber,
                    Address = registrationRequestDto.Address,
                    Designation = registrationRequestDto.Designation,
                    Bloodgroup = registrationRequestDto.BloodGroup,
                    MaritalStatus = registrationRequestDto.MaritalStatus
                };

                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    return user.Id; // Return UserID on successful registration
                }

                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
            {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginRequestDto.Password))
                {
                    var token = GenerateJwtToken(user);
                    return new LoginResponseDto
                    {
                        Token = token,
                        UserId = user.Id
                    };
                }

                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            private string GenerateJwtToken(ApplicationUser user)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

                var userRoles = _userManager.GetRolesAsync(user).Result;
                claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            public async Task<bool> AssignRole(string email, string roleName)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }

                var result = await _userManager.AddToRoleAsync(user, roleName);
                return result.Succeeded;
            }

            public async Task<IEnumerable<UserDto>> GetUsers()
            {
                var users = _userManager.Users.Select(u => new UserDto
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Address = u.Address,
                    Designation = u.Designation,
                    BloodGroup = u.Bloodgroup,
                    MaritalStatus = u.MaritalStatus
                });

                return await Task.FromResult(users.ToList());
            }

            public async Task<IEnumerable<UserDto>> GetUserDto(string userId)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null) throw new Exception("User not found.");

                return new List<UserDto>
            {
                new UserDto
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    Designation = user.Designation,
                    BloodGroup = user.Bloodgroup,
                    MaritalStatus = user.MaritalStatus
                }
            };
            }

            public async Task<UserDataDto> GetUserId()
            {
                // Add logic to retrieve currently logged-in user details if needed.
                throw new NotImplementedException();
            }
        }
    



}

