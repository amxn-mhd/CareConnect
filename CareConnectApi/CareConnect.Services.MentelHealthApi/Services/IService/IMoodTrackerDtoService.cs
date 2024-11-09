using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IMoodTrackerDtoService
    {
        IEnumerable<MoodTrackerDto> GetUserMood();

        IEnumerable<MoodTrackerDto> GetUserMoodsByID(int id);

        MoodTrackerDto GetUserMoodByDate(DateOnly date);
    }
}
