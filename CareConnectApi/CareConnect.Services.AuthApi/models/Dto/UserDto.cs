
namespace CareConnect.Services.AuthApi.models.Dto
{
    public class UserDto
    {
        public string UserId { get; set; } = string.Empty; // Ensure it's initialized
        public string UserName { get; set; } = string.Empty; // Prevent null issues

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? Address { get; set; } // Nullable as it might not always be provided

        public string Designation { get; set; } = string.Empty;

        public string BloodGroup { get; set; } = string.Empty;

        public string? MaritalStatus { get; set; }

    }
}
