using CareConnect.Services.AuthApi.models.Dto;

namespace CareConnect.Services.AuthApi.Service.IAuthService
{
    public interface IAuthService
    {
       Task<string> Register(RegistrationRequestDto registrationRequestDto);
       Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        //// this is for role management/.
        Task<bool> AssignRole(string email, string rolename);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<IEnumerable<UserDto>> GetUserDto( string Userid);

        Task<UserDataDto> GetUserId();



        
    }
}
