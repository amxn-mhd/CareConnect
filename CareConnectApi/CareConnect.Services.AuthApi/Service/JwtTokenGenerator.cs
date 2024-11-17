using CareConnect.Services.AuthApi.models;
//using CareConnect.Services.AuthApi.Service.IAuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CareConnect.Services.AuthApi.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator

    {

        private readonly JwtOptions _jwtOptions;

        private readonly UserManager<ApplicationUser> _userManager; // Add UserManager to get roles



        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager)

        {

            _jwtOptions = jwtOptions.Value;

            _userManager = userManager; // Initialize UserManager

        }



        public async Task<string> GenerateToken(ApplicationUser applicationUser)

        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);



            // Base claims (email, id, and username)

            var claimList = new List<Claim>

      {

        new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),

        new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),

        new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName)

      };



            // Fetch roles for the user and add them as claims

            var roles = await _userManager.GetRolesAsync(applicationUser);

            foreach (var role in roles)

            {

                claimList.Add(new Claim(ClaimTypes.Role, role));

            }



            // Token descriptor with additional role claims

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Audience = _jwtOptions.Audience,

                Issuer = _jwtOptions.Issuer,

                Subject = new ClaimsIdentity(claimList),

                Expires = DateTime.UtcNow.AddDays(7),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };



            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }





    }
}
