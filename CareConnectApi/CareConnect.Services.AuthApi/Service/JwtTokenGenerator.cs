using CareConnect.Services.AuthApi.models;
using CareConnect.Services.AuthApi.Service.IAuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareConnect.Services.AuthApi.Service
{
    public class JwtTokenGenerator:IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)

        {

            _jwtOptions = jwtOptions.Value;

        }

        public async Task<string> GenerateToken(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager)
        {
            if (applicationUser == null)
                throw new ArgumentNullException(nameof(applicationUser), "Application user cannot be null.");

            if (string.IsNullOrWhiteSpace(applicationUser.Email) || string.IsNullOrWhiteSpace(applicationUser.Id))
                throw new ArgumentException("Application user must have valid Email and Id.");

            if (string.IsNullOrWhiteSpace(_jwtOptions.Secret))
                throw new ArgumentNullException(nameof(_jwtOptions.Secret), "JWT Secret cannot be null or empty.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Secret);

            var claimList = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
        new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
        new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName),
    };

            // Retrieve user roles and add to claims
            //var roles = await userManager.GetRolesAsync(applicationUser);
            //if (roles != null)
            //{
            //    foreach (var role in roles)
            //    {
            //        claimList.Add(new Claim(ClaimTypes.Role, role));
            //    }
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
