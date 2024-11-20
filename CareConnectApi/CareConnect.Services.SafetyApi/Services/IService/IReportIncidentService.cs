using CareConnect.Services.SafetyApi.Models;
//using CareConnect.Services.WellBeingApi.Models;
using System;
using System.Collections.Generic;

namespace CareConnect.Services.SafetyApi.Services.IService
{
    public interface IReportIncidentService
    {
        Task<IEnumerable<ReportIncident>> GetUserReportLog();

        bool AddUserReportLog(ReportIncident userReportLog);


        bool UpdateUserReportLog( ReportIncident updatedIncident);

        bool DeleteUserReportLog(int incidentId, string userId);
    }
}
