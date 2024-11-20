using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface IReminderSchedulerService
    {
        IEnumerable<ReminderScheduler> GetUserReminderLog();

        bool AddUserReminderLog(ReminderScheduler userReminderLog);


        bool DeleteUserReminderLog(int Totalreminders ,string id );
    }
}
