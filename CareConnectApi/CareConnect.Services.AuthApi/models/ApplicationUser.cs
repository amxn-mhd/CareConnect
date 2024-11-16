using Microsoft.AspNetCore.Identity;

namespace CareConnect.Services.AuthApi.models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string   Designation { get; set; }

        public string Bloodgroup { get; set; }

        public string MaritalStatus {  get; set; }


    }
}
