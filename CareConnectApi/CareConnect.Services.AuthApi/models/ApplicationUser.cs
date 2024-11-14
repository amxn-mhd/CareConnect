using Microsoft.AspNetCore.Identity;

namespace CareConnect.Services.AuthApi.models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
