using CareConnect.Services.SafetyApi.Models;
//using CareConnect.Services.WellBeingApi.Models;
using System;

namespace CareConnect.Services.SafetyApi.Services.IService
{
    public interface IReportIncidentDtoService
    {
        IEnumerable<ReportIncidentDto> GetUserReport();

        IEnumerable<ReportIncidentDto> GetUserReportByID(int id);

        ReportIncidentDto GetUserReportByDate(DateOnly date);
        
    }
}
