﻿using System;
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
        public async Task<IActionResult> GetMoodTracker()
        {
            var result = _mTService.GetUserMoodLog();
            return Ok(result);
        }

        [HttpGet("getMoodData")]
        public async Task<IActionResult> GetMood()
        {
            var result = _mTDtoService.GetUserMood();
            return Ok(result);
        }


        // GET: api/MoodTrackers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoodByDate(DateTime id)
        {
            var moodTracker = _mTDtoService.GetUserMoodByDate(id);

            if (moodTracker == null)
            {
                return NotFound();
            }

            return Ok(moodTracker);
        }


        // POST: api/MoodTrackers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostMoodTracker(MoodTracker moodTracker)
        {
            var result= _mTService.AddUserMoodLog(moodTracker);

            return Ok(result);
        }

        // DELETE: api/MoodTrackers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoodTracker(DateTime id)
        {
            var res =  _mTService.DeleteUserMoodLog(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }

        
    }
}
