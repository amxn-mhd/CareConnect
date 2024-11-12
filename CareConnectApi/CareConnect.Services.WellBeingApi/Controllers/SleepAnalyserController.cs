using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services;
using CareConnect.Services.WellBeingApi.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CareConnect.Services.WellBeingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepAnalyserController : ControllerBase
    {
        private readonly ISleepAnalyserDtoService _sTDtoService;
        private readonly ISleepAnalyserService _sTService;
        private object _stService;

        public SleepAnalyserController(ISleepAnalyserService sleepAnalyserService, ISleepAnalyserDtoService sleepAnalyserDtoService)
        {
            _sTService = sleepAnalyserService;
            _sTDtoService = sleepAnalyserDtoService;
        }

        // GET: api/MoodTrackers
        [HttpGet]
        public async Task<IActionResult> GetSleepTracker()
        {
            var result = _sTService.GetUserSleepLog();
            return Ok(result);
        }

        [HttpGet("getSleepData")]
        public async Task<IActionResult> GetSleep()
        {
            var result = _sTDtoService.GetUserSleep();
            return Ok(result);
        }


        // GET: api/SleepAnalyser/5
        [HttpGet("{Date}")]
        public async Task<IActionResult> GetSleepByDate(DateOnly Date)
        {
            var sleepAnalyser = _sTDtoService.GetUserSleepByDate(Date);

            if (sleepAnalyser == null)
            {
                return NotFound();
            }

            return Ok(sleepAnalyser);
        }


        // POST: api/SleepAnalyser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSLeepTracker(SleepAnalyser sleepAnalyser)
        {
            var result = _sTService.AddUserSleepLog(sleepAnalyser);

            return Ok(result);
        }

        // DELETE: api/SleepAnalyser/5
        [HttpDelete("{Date}")]
        public async Task<IActionResult> DeleteSleepAnalyser(DateOnly Date)
        {
            var res = _sTService.DeleteUserSleepLog(Date);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
