using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;

namespace CareConnect.Services.WellBeingApi.Services
{
    public class ReminderSchedulerService : IReminderSchedulerService
    {
        private readonly WellBeingApiContext _db;

        public ReminderSchedulerService(WellBeingApiContext db)
        {
            _db = db;
        }

        public IEnumerable<ReminderScheduler> GetUserReminderLog()
        {
            return _db.ReminderScheduler.ToList();
        }

        public bool AddUserReminderLog(ReminderScheduler userReminderLog)
        {
            if (userReminderLog != null)
            {
                _db.ReminderScheduler.Add(userReminderLog);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserReminderLog(DateOnly date)
        {
            if (date != DateOnly.MinValue)
            {
                var result = _db.ReminderScheduler.FirstOrDefault(u => u.DateTimeOfEntry == date);
                if (result != null)
                {
                    _db.ReminderScheduler.Remove(result);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserReminderLog(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
