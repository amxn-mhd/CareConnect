using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Services.IService
{
    public interface IMoodTrackerDtoService
    {
        IEnumerable<MoodTrackerDto> GetUserMood(int id);// get mood by id 

        MoodTrackerDto GetUserMoodByDate(int id, DateOnly date);// get mood of perticular date 


    }
}
