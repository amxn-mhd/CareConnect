using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IMoodTrackerService
    {
        IEnumerable<MoodTracker> GetUserMoodLog();

        IEnumerable<MoodTracker> GetUsersByDoctor(int docId);

        bool AddUserMoodLog(MoodTracker userMoodLog);

        bool UpdateUserMoodLog(MoodTracker userMoodLog);

        bool DeleteUserMoodLog(int id ,DateOnly date);





    }
}
