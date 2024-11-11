using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface ISleepAnalyserService
    {
        IEnumerable<SleepAnalyser> GetUserSleepLog();

        bool AddUserSleepLog(SleepAnalyser userSleepLog);

        bool UpdateUserSleepLog(int id, DateOnly date);

        bool DeleteUserSleepLog(DateOnly date);
    }
}
