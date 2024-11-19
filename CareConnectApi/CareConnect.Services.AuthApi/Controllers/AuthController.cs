using CareConnect.Services.AuthApi.models.Dto;
using CareConnect.Services.AuthApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareConnect.Services.AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {



        private readonly IAuthService _authService;

        private readonly ResponseDto _response = new ResponseDto();

        private readonly IConsumerService _consumerService;

        public AuthController(IAuthService authService, IConsumerService consumerService)

        {

            _authService = authService;

            _consumerService = consumerService;

        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)

        {

            var errorMessage = await _authService.Register(model);

            if (!string.IsNullOrEmpty(errorMessage))

            {

                _response.IsSuccess = false;

                _response.Message = errorMessage;

                return BadRequest(_response);

            }

            return Ok(_response);

        }



        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)

        {

            var result = await _authService.Login(model);

            if (result.User == null)

            {

                _response.IsSuccess = false;

                _response.Message = "Invalid credentials.";

                return BadRequest(_response);

            }

            _response.Result = result;

            return Ok(_response);

        }





    }
}
