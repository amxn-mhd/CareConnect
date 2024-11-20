﻿using CareConnect.Services.SafetyApi.Models;
using CareConnect.Services.SafetyApi.Services.IService;
//using CareConnect.Services.WellBeingApi.Models;
//using CareConnect.Services.WellBeingApi.Services;
//using CareConnect.Services.WellBeingApi.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CareConnect.Services.SafetyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportIncidentController : ControllerBase
    {
        private readonly IReportIncidentDtoService _rTDtoService;
        private readonly IReportIncidentService _rTService;
        private object _rtService;

        public ReportIncidentController(IReportIncidentService reportIncidentService, IReportIncidentDtoService reportIncidentDtoService)
        {
            _rTService = reportIncidentService;
            _rTDtoService = reportIncidentDtoService;
        }

        // GET: api/MoodTrackers
        [HttpGet]
        public async Task<IActionResult> GetReportLog()// all user data 
        {
            var result = await _rTService.GetUserReportLog();
            return Ok(result);
        }


        // POST: api/SleepAnalyser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReportTracker(ReportIncident reportIncident)
        {
            var result = _rTService.AddUserReportLog(reportIncident);

            return Ok(result);
        }

        // DELETE: api/SleepAnalyser/5

        [HttpDelete]
        public async Task<IActionResult> DeleteReportAnalyser(int incidentid, string userid )
        {
            var res = _rTService.DeleteUserReportLog(incidentid, userid);

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }


        [HttpPut("updateReport")]

        public async Task<IActionResult> PutReportData( ReportIncident updatedIncident)
        {
           
            var res = _rTService.UpdateUserReportLog( updatedIncident);


            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }


        //dtos Actions 

        [HttpGet("getReportData")]

        public async Task<IActionResult> GetReport(string userid )//perticular user data 
        {
            var result =await _rTDtoService.GetUserEventData(userid);
            return Ok(result);
        }


        // GET: api/SleepAnalyser/5
        [HttpGet("{Date}")]

        public async Task<IActionResult> GetReportByDate(string userid ,DateOnly Date)
        {
            var reportIncident = await _rTDtoService.GetUserEventByDate(userid,Date);

            if (reportIncident == null)
            {
                return NotFound();
            }

            return Ok(reportIncident);
        }


       


    }
}
