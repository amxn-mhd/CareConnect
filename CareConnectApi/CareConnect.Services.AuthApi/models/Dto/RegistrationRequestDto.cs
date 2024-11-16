namespace CareConnect.Services.AuthApi.models.Dto
{
    public class RegistrationRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string Password { get; set; }
    }
}
