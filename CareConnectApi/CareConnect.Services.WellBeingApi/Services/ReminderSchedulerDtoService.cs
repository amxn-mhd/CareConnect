using AutoMapper;
//using CareConnect.Services.WellBeingApi.Data;
using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;

namespace CareConnect.Services.WellBeingApi.Services
{
    public class ReminderSchedulerDtoService : IReminderSchedulerDtoService
    {
        private readonly WellBeingApiContext _db;
        private readonly IMapper _mapper;

        public ReminderSchedulerDtoService(IMapper mapper, WellBeingApiContext reminderSchedulerApiContext)
        {
            _mapper = mapper;
            _db = reminderSchedulerApiContext;
        }

        public ReminderSchedulerDto MapSourceToDestination(ReminderScheduler reminderScheduler)
        {
            return _mapper.Map<ReminderSchedulerDto>(reminderScheduler);
        }
        public IEnumerable<ReminderSchedulerDto> GetUserReminderByUser(int id , DateOnly date )
        {

            var result = _db.ReminderScheduler.Where(i =>i.UserId==id && i.DateTimeOfEntry==date).ToList();
            return _mapper.Map<IEnumerable<ReminderSchedulerDto>>(result);
        }




        public ReminderSchedulerDto GetUserReminderByDate(DateOnly date)
        {
            var result = _db.ReminderScheduler.FirstOrDefault(i => i.DateTimeOfEntry == date);
            return _mapper.Map<ReminderSchedulerDto>(result);
        }

        public IEnumerable<ReminderSchedulerDto> GetUserReminderByID(int id)
        {
            var result = _db.ReminderScheduler.Select(i => i.UserId == id);
            return _mapper.Map<IEnumerable<ReminderSchedulerDto>>(result);

        }
    }
}
