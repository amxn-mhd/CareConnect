using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface IReminderSchedulerDtoService
    {
        IEnumerable<ReminderSchedulerDto> GetUserReminder();

        IEnumerable<ReminderSchedulerDto> GetUserReminderByID(int id);

        ReminderSchedulerDto GetUserReminderByDate(DateOnly date);
        
    }
}
