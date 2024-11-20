using CareConnect.Services.AuthApi.Data;
using CareConnect.Services.AuthApi.models.Dto;
using CareConnect.Services.AuthApi.models;

using Microsoft.AspNetCore.Identity;


namespace CareConnect.Services.AuthApi.Service
{
    public class AuthService :IAuthService

    {

        private readonly AppDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ResponseDto _response = new ResponseDto();



        public AuthService(AppDbContext dbContext, UserManager<ApplicationUser> userManager,

                  IJwtTokenGenerator jwtTokenGenerator, RoleManager<IdentityRole> roleManager)

        {

            _dbContext = dbContext;

            _userManager = userManager;

            _jwtTokenGenerator = jwtTokenGenerator;

            _roleManager = roleManager;

        }



        public async Task<string> Register(RegistrationRequestDto request)

        {

            var user = new ApplicationUser

            {

                UserName = request.Email,

                Email = request.Email,

                Name = request.Name,

                PhoneNumber = request.PhoneNumber,

                Role = request.Role,
                Age = request.Age,
                BloodGroup=request.BloodGroup,
                MaritalStatus=request.MaritalStatus,
                JobDescription=request.JobDescription
    };



            var result = await _userManager.CreateAsync(user, request.Password);





            if (!await _roleManager.RoleExistsAsync(request.Role))

            {

                var roleResult = await _roleManager.CreateAsync(new IdentityRole(request.Role));

                if (!roleResult.Succeeded)

                {

                    _response.Message = "Role creation failed";



                }

            }



            var roleAssignmentResult = await _userManager.AddToRoleAsync(user, request.Role);

            if (!roleAssignmentResult.Succeeded)

            {

                _response.Message = "Role assignment to user failed";



            }





            return result.Errors.FirstOrDefault()?.Description;

        }



        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)

        {

            var user = await _userManager.FindByNameAsync(loginRequestDto.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequestDto.Password))

            {

                return new LoginResponseDto { User = null, Token = "", Role = "" };

            }



            // Generate the token and await the result

            var token = await _jwtTokenGenerator.GenerateToken(user); // Make sure to await this



            // Retrieve user role

            var roles = await _userManager.GetRolesAsync(user);

            var role = roles.FirstOrDefault(); // Assuming single role per user



            // Populate UserDto with user's details

            var userDto = new UserDto

            {

                Id = user.Id,

                Name = user.Name,

                Email = user.Email,

                PhoneNumber = user.PhoneNumber,
                BloodGroup =user.BloodGroup


    };



            // Return the response with populated UserDto, Token, and Role

            return new LoginResponseDto

            {

                User = userDto,

                Token = token,

                Role = role

            };

        }



   
    
    }
}
