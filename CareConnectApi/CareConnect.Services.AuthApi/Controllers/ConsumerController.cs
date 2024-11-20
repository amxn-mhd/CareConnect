using CareConnect.Services.AuthApi.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CareConnect.Services.AuthApi.Controllers
{
    [Route("api/consumer")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;



        public ConsumerController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)

        {

            _userManager = userManager;

            _roleManager = roleManager;

        }



        [HttpGet("consumers")]

        public async Task<IActionResult> GetConsumers()

        {

            // Ensure the Employee role exists

            var consumerRole = await _roleManager.FindByNameAsync("User");

            if (consumerRole == null)

            {

                return NotFound("User role not found.");

            }



            // Find users assigned the Employee role

            var consumers = await _userManager.GetUsersInRoleAsync("User");



            // Map users to a response model or return directly

            var consumerDtos = consumers.Select(e => new

            {

                e.Id,

                e.Name,

                e.Email,

                e.Age,

                e.BloodGroup


            });



            return Ok(consumerDtos);

        }

    }
}

