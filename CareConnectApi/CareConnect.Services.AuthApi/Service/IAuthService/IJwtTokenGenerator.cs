using CareConnect.Services.AuthApi.models;
using Microsoft.AspNetCore.Identity;

namespace CareConnect.Services.AuthApi.Service.IAuthService
{
        public interface IJwtTokenGenerator
        {
            Task<string> GenerateToken(ApplicationUser applicationUser, UserManager<ApplicationUser> userManager);
        }
    }

