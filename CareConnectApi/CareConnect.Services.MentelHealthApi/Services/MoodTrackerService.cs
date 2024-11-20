using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.MentelHealthApi.Services.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CareConnect.Services.MentelHealthApi.Services
{
    public class MoodTrackerService : IMoodTrackerService
    {
        private readonly MentelHealthApiContext _db;

        public MoodTrackerService(MentelHealthApiContext db)
        {
            _db = db;
        }

        public IEnumerable<MoodTracker> GetUserMoodLog()// get whole data 
        {
            return _db.MoodTrackers.ToList();
        }

        public bool AddUserMoodLog(MoodTracker userMoodLog)
        {
            try
            {
                var result = _db.MoodTrackers.FirstOrDefault(u => u.DateTimeOfEntry == userMoodLog.DateTimeOfEntry && u.UserId == userMoodLog.UserId);
                if (result == null)
                {
                    _db.MoodTrackers.Add(userMoodLog);
                   
                }
                else
                {
                    result.CurrentMood = userMoodLog.CurrentMood;
                    result.DateTimeOfEntry = userMoodLog.DateTimeOfEntry;
                    result.UserId = userMoodLog.UserId;
                    result.Name = userMoodLog.Name;
                    result.Score = userMoodLog.Score;
                    result.DoctorID = userMoodLog.DoctorID;
                   // UpdateUserMoodLog(userMoodLog);
                }
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding/updating user mood log: {ex.Message}");

                return false;
            }

        }

        public bool DeleteUserMoodLog(string id, DateOnly date)// add also userid 
        {
            try
            {
                if (date != DateOnly.MinValue)
                {
                    var result = _db.MoodTrackers.FirstOrDefault(u => u.DateTimeOfEntry == date && u.UserId == id);
                    if (result != null)
                    {
                        _db.MoodTrackers.Remove(result);
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            return false;
        }

        public bool UpdateUserMoodLog(MoodTracker moodTracker)
        {
            var result = _db.MoodTrackers.FirstOrDefault(u => u.DateTimeOfEntry == moodTracker.DateTimeOfEntry && u.UserId == moodTracker.UserId);
            
            if (result != null)
            {
                try
                {
                    result.CurrentMood = moodTracker.CurrentMood;
                    result.DateTimeOfEntry = moodTracker.DateTimeOfEntry;
                    result.UserId = moodTracker.UserId;
                    result.Name = moodTracker.Name;
                    result.Score = moodTracker.Score;
                    result.DoctorID = moodTracker.DoctorID;
                    _db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
            else
            {
                return false;
            }

        }
        public IEnumerable<MoodTracker> GetUsersByDoctor(int docId)
        {
            var result = _db.MoodTrackers.Where(u => u.DoctorID == docId).ToList();

            return result;

        }

    }
}
