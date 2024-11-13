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

        // GET: api/MoodTrackers
        [HttpGet]
        public async Task<IActionResult> GetReminderTracker()
        {
            var result = _rTService.GetUserReminderLog();
            return Ok(result);
        }

        [HttpGet("getReminderData")]
        public async Task<IActionResult> GetReminder()
        {
            var result = _rTDtoService.GetUserReminder();
            return Ok(result);
        }


        // GET: api/SleepAnalyser/5
        [HttpGet("{Date}")]
        public async Task<IActionResult> GetReminderByDate(DateOnly Date)
        {
            var reminderScheduler = _rTDtoService.GetUserReminderByDate(Date);

            if (reminderScheduler == null)
            {
                return NotFound();
            }

            return Ok(reminderScheduler);
        }


        // POST: api/SleepAnalyser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReminderTracker(ReminderScheduler reminderScheduler)
        {
            var result = _rTService.AddUserReminderLog(reminderScheduler);

            return Ok(result);
        }

        // DELETE: api/SleepAnalyser/5
        [HttpDelete("{Date}")]
        public async Task<IActionResult> DeleteReminderAnalyser(DateOnly Date)
        {
            var res = _rTService.DeleteUserReminderLog(Date);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
