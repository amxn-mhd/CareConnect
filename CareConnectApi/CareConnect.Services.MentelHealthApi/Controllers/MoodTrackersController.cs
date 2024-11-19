using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareConnect.Services.MentelHealthApi.Models;
using AutoMapper;
using CareConnect.Services.MentelHealthApi.Services.IService;

namespace CareConnect.Services.MentelHealthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodTrackersController : ControllerBase
    {
        private readonly IMoodTrackerDtoService _mTDtoService;
        private readonly IMoodTrackerService _mTService;
        private object _mtService;

        public MoodTrackersController(IMoodTrackerService moodTrackerService, IMoodTrackerDtoService moodTrackerDtoService)
        {
            _mTService = moodTrackerService;
            _mTDtoService = moodTrackerDtoService;
        }

        // GET: api/MoodTrackers
        [HttpGet]
        public IActionResult GetMoodTracker()
        {
            var result = _mTService.GetUserMoodLog();//getall
            return Ok(result);
        }

      


        // POST: api/MoodTrackers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostMoodTracker(MoodTracker moodTracker)// post whole data 
        {
            var result = _mTService.AddUserMoodLog(moodTracker);

            return Ok(result);
        }

        // DELETE: api/MoodTrackers/5
        [HttpDelete("{id,Date}")]
        public async Task<IActionResult> DeleteMoodTracker(string id , DateOnly Date)// delete whole .
        {
            var res = _mTService.DeleteUserMoodLog(id, Date);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }


        [HttpGet("getMoodDataByUserID")] 
        public IActionResult GetMood(string userid)
        {
            var result = _mTDtoService.GetUserMood(userid);
            return Ok(result);
        }
        

        [HttpGet("GetUsersByDoctor")]
        public IActionResult GetUsersByDoc(int docid)
        {
            var result = _mTService.GetUsersByDoctor(docid);
            return Ok(result);
        }

        // GET: api/MoodTrackers/5  
        [HttpGet("GetMoodByDate")]
        public IActionResult GetMoodByDate(string userid)
        {
            var moodTracker = _mTDtoService.GetUserMoodByDate(userid);

            if (moodTracker == null)
            {
                return NotFound();
            }

            return Ok(moodTracker);
        }




    }
}
