using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.MentelHealthApi.Services.IService;

namespace CareConnect.Services.MentelHealthApi.Services
{
    public class MoodTrackerService : IMoodTrackerService
    {
        private readonly MentelHealthApiContext _db;

        public MoodTrackerService(MentelHealthApiContext db)
        {
            _db = db;
        }

        public IEnumerable<MoodTracker> GetUserMoodLog()
        {
            return _db.MoodTrackers.ToList();
        }

       public  bool AddUserMoodLog(MoodTracker userMoodLog)
        {
            if (userMoodLog != null)
            {
                _db.MoodTrackers.Add(userMoodLog);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserMoodLog(DateOnly date)
        {
            if (date != DateOnly.MinValue)
            {
                var result = _db.MoodTrackers.FirstOrDefault(u => u.DateTimeOfEntry == date);
                if (result != null)
                {
                    _db.MoodTrackers.Remove(result);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserMoodLog(int id, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
