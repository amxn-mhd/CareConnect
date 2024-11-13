using AutoMapper;
using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;

namespace CareConnect.Services.WellBeingApi.Services
{
    
        public class SleepAnalyserDtoService : ISleepAnalyserDtoService
        {
            private readonly WellBeingApiContext _db;
            private readonly IMapper _mapper;

            public SleepAnalyserDtoService(IMapper mapper, WellBeingApiContext sleepAnalyserApiContext)
            {
                _mapper = mapper;
                _db = sleepAnalyserApiContext;
            }

            public SleepAnalyserDto MapSourceToDestination(SleepAnalyser sleepAnalyser)
            {
                return _mapper.Map<SleepAnalyserDto>(sleepAnalyser);
            }
            public IEnumerable<SleepAnalyserDto> GetUserSleep()
            {
                var result = _db.SleepAnalyser.ToList();
                return _mapper.Map<IEnumerable<SleepAnalyserDto>>(result);
            }




            public SleepAnalyserDto GetUserSleepByDate(DateOnly date)
            {
                var result = _db.SleepAnalyser.FirstOrDefault(i => i.DateTimeOfEntry == date);
                return _mapper.Map<SleepAnalyserDto>(result);
            }

            public IEnumerable<SleepAnalyserDto> GetUserSleepByID(int id)
            {
                var result = _db.SleepAnalyser.Select(i => i.UserId == id);
                return _mapper.Map<IEnumerable<SleepAnalyserDto>>(result);

            }
        }
    }
