using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;
using System.Collections.Generic;

namespace CareConnect.Services.WellBeingApi.Services
{
    public class SleepAnalyserService : ISleepAnalyserService
    {
        private readonly WellBeingApiContext _db;

        public SleepAnalyserService(WellBeingApiContext db)
        {
            _db = db;
        }

        public IEnumerable<SleepAnalyser> GetUserSleepLog()
        {
            return _db.SleepAnalyser.ToList();
        }

        public bool AddUserSleepLog(SleepAnalyser userSleepLog)
        {
            if (userSleepLog != null)
            {
                _db.SleepAnalyser.Add(userSleepLog);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserSleepLog(DateOnly date)
        {
            if (date != DateOnly.MinValue)
            {
                var result = _db.SleepAnalyser.FirstOrDefault(u => u.DateTimeOfEntry == date);
                if (result != null)
                {
                    _db.SleepAnalyser.Remove(result);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserSleepLog(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
