using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services;
using CareConnect.Services.WellBeingApi.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareConnect.Services.WellBeingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderSchedulerController : ControllerBase
    {
        private readonly IReminderSchedulerDtoService _rTDtoService;
        private readonly IReminderSchedulerService _rTService;
        private object _rtService;

        public ReminderSchedulerController(IReminderSchedulerService reminderSchedulerService, IReminderSchedulerDtoService reminderSchedulerDtoService)
        {
            _rTService = reminderSchedulerService;
            _rTDtoService = reminderSchedulerDtoService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetReminderTracker() //get all 
        {
            var result = _rTService.GetUserReminderLog();
            return Ok(result);
        }

        [HttpGet("getReminderData")]
        public async Task<IActionResult> GetReminder(int userid ,DateOnly date) // dto get only required .
        {
            var result = _rTDtoService.GetUserReminderByUser(userid,date);
            return Ok(result);
        }


      


        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReminderTracker(ReminderScheduler reminderScheduler)
        {
            var result = _rTService.AddUserReminderLog(reminderScheduler);

            return Ok(result);
        }

        // DELETE: api/SleepAnalyser/5
        [HttpDelete("{Date}")]
        public async Task<IActionResult> DeleteReminderAnalyser(int id,DateOnly Date)
        {
            var res = _rTService.DeleteUserReminderLog(id ,Date);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
