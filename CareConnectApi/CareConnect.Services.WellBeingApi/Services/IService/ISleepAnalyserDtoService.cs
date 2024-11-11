using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface ISleepAnalyserDtoService
    {
        IEnumerable<SleepAnalyserDto> GetUserSleep();

        IEnumerable<SleepAnalyserDto> GetUserSleepByID(int id);

        SleepAnalyserDto GetUserSleepByDate(DateOnly date);
    }
}
