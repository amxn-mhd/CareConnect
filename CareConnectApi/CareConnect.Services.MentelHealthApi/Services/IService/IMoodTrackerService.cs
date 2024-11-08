using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IMoodTrackerService
    {
        IEnumerable<MoodTracker> GetUserMoodLog();

        bool AddUserMoodLog(MoodTracker userMoodLog);

        bool UpdateUserMoodLog(int id, DateTime date);

        bool DeleteUserMoodLog(DateTime date);





    }
}
