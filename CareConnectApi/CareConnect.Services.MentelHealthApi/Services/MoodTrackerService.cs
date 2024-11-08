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
            return _db.MoodTracker.ToList();
        }

       public  bool AddUserMoodLog(MoodTracker userMoodLog)
        {
            if (userMoodLog != null)
            {
                _db.MoodTracker.Add(userMoodLog);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserMoodLog(DateTime date)
        {
            if (date != DateTime.MinValue)
            {
                var result = _db.MoodTracker.FirstOrDefault(u => u.DateTimeOfEntry == date);
                if (result != null)
                {
                    _db.MoodTracker.Remove(result);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUserMoodLog(int id, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
