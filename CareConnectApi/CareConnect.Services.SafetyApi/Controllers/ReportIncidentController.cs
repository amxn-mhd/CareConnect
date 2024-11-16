using CareConnect.Services.SafetyApi.Models;
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
        public async Task<IActionResult> GetReportTracker()
        {
            var result = _rTService.GetUserReportLog();
            return Ok(result);
        }

        [HttpGet("getReportData")]
        public async Task<IActionResult> GetReport()
        {
            var result = _rTDtoService.GetUserReport();
            return Ok(result);
        }


        // GET: api/SleepAnalyser/5
        [HttpGet("{Date}")]
        public async Task<IActionResult> GetReportByDate(DateOnly Date)
        {
            var reportIncident = _rTDtoService.GetUserReportByDate(Date);

            if (reportIncident == null)
            {
                return NotFound();
            }

            return Ok(reportIncident);
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
        [HttpDelete("{Date}")]
        public async Task<IActionResult> DeleteReportAnalyser(DateOnly Date)
        {
            var res = _rTService.DeleteUserReportLog(Date);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);

        }
    }
}
