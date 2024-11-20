using CareConnect.Services.AuthApi.models;

namespace CareConnect.Services.AuthApi.Service
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(ApplicationUser applicationUser);
    }
}
