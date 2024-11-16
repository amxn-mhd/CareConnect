using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface IReminderSchedulerDtoService
    {

        IEnumerable<ReminderSchedulerDto> GetUserReminderByUser(int id,DateOnly date);

        
    }
}
