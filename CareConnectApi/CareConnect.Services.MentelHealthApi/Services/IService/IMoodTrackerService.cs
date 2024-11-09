using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IMoodTrackerService
    {
        IEnumerable<MoodTracker> GetUserMoodLog();

        bool AddUserMoodLog(MoodTracker userMoodLog);

        bool UpdateUserMoodLog(int id, DateOnly date);

        bool DeleteUserMoodLog(DateOnly date);





    }
}
