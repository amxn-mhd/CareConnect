namespace CareConnect.Services.AuthApi.models.Dto
{
    public class RegistrationRequestDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int? Age { get; set; }
        public string? BloodGroup { get; set; }
        public string? MaritalStatus { get; set; }
        public string? JobDescription { get; set; }
        public string Role { get; set; } = "User";

    }
}
