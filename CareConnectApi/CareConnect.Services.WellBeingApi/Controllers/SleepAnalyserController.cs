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
        private readonly ISleepAnalyserService _sTService;
        private object _stService;

        public SleepAnalyserController(ISleepAnalyserService sleepAnalyserService)
        {
            _sTService = sleepAnalyserService;
        }

        // GET: api/MoodTrackers
        [HttpGet]
        public async Task<IActionResult> GetSleepTrack(string userid)// get all 
        {
            var result = _sTService.GetUserSleepLog(userid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{userid}/{date}")]
        public async Task<IActionResult> GetSleepData(string userid,DateOnly date)// get all 
        {
            var result = _sTService.GetDataByUserDate( userid,date);
            return Ok(result);
        }


        // POST: api/SleepAnalyser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSLeepTracker(SleepAnalyser sleepAnalyser)//add or update 
        {
            var result = _sTService.AddUserSleepLog(sleepAnalyser);

            return Ok(result);
        }

        // DELETE: api/SleepAnalyser/5
        [HttpDelete] 
        public async Task<IActionResult> DeleteSleepAnalyser(int EntryId, string useri)//delete.
        {
            var res = _sTService.DeleteUserSleepLog(EntryId, useri);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
