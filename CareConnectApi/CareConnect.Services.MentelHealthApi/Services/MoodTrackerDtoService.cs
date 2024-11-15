using AutoMapper;
using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.MentelHealthApi.Services.IService;
using System.Collections.Generic;

namespace CareConnect.Services.MentelHealthApi.Services
{
    public class MoodTrackerDtoService : IMoodTrackerDtoService
    {
        private readonly MentelHealthApiContext _db;
        private readonly IMapper _mapper;

    public MoodTrackerDtoService(IMapper mapper,MentelHealthApiContext mentelHealthApiContext)
    {
        _mapper = mapper;
            _db = mentelHealthApiContext;
    }

    public MoodTrackerDto MapSourceToDestination(MoodTracker moodTracker)
    {
        return _mapper.Map<MoodTrackerDto>(moodTracker);
    }
        public IEnumerable<MoodTrackerDto> GetUserMood(int id)
        {
            var result = _db.MoodTrackers.Where(i => i.UserId == id).ToList();
            return _mapper.Map<IEnumerable< MoodTrackerDto >> (result);
        }
        
        public MoodTrackerDto GetUserMoodByDate(int id , DateOnly date)
        {
            var result=_db.MoodTrackers.FirstOrDefault(i =>i.DateTimeOfEntry==date && i.UserId==id);
            return _mapper.Map<MoodTrackerDto>(result);
        }


        
    }
}
