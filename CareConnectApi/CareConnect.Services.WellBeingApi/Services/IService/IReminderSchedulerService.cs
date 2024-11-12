using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface IReminderSchedulerService
    {
        IEnumerable<ReminderScheduler> GetUserReminderLog();

        bool AddUserReminderLog(ReminderScheduler userReminderLog);

        bool UpdateUserReminderLog(int id, DateOnly date);

        bool DeleteUserReminderLog(DateOnly date);
    }
}
