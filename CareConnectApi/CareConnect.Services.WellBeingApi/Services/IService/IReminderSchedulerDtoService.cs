using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface IReminderSchedulerDtoService
    {

        IEnumerable<ReminderSchedulerDto> GetUserReminderByUser(string id,DateOnly date);

        
    }
}
