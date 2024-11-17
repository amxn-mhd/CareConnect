namespace CareConnect.Services.AuthApi.models.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
