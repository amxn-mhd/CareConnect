using CareConnect.Services.SafetyApi.Models;
using CareConnect.Services.SafetyApi.Services.IService;
//using CareConnect.Services.WellBeingApi.Models;
//using CareConnect.Services.WellBeingApi.Services.IService;
using System.Collections.Generic;

namespace CareConnect.Services.SafetyApi.Services
{
    public class ReportIncidentService : IReportIncidentService
    {
        private readonly SafetyApiContext _db;

        public ReportIncidentService(SafetyApiContext db)
        {
            _db = db;
        }

        public IEnumerable<ReportIncident> GetUserReportLog()
        {
            return _db.ReportIncident.ToList();
        }

        public bool AddUserReportLog(ReportIncident userReportLog)
        {
            if (userReportLog != null)
            {
                _db.ReportIncident.Add(userReportLog);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserReportLog(DateOnly date)
        {
            if (date != DateOnly.MinValue)
            {
                var result = _db.ReportIncident.FirstOrDefault(u => u.DateTimeOfEntry == date);
                if (result != null)
                {
                    _db.ReportIncident.Remove(result);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserReportLog(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
