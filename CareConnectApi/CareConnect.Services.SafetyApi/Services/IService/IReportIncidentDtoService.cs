using CareConnect.Services.SafetyApi.Models;
using System;

namespace CareConnect.Services.SafetyApi.Services.IService
{
    public interface IReportIncidentDtoService
    {


        Task<IEnumerable<ReportIncidentDto>> GetUserEventData(string id);

        Task<IEnumerable<ReportIncidentDto>> GetUserEventByDate(string id , DateOnly date);
        
    }
}
   
