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
        public IEnumerable<MoodTrackerDto> GetUserMood()
        {
            var result = _db.MoodTrackers.ToList();
            return _mapper.Map<IEnumerable< MoodTrackerDto >> (result);
        }
        

        

        public MoodTrackerDto GetUserMoodByDate(DateOnly date)
        {
            var result=_db.MoodTrackers.FirstOrDefault(i =>i.DateTimeOfEntry==date);
            return _mapper.Map<MoodTrackerDto>(result);
        }

        public IEnumerable<MoodTrackerDto> GetUserMoodsByID(int id)
        {
            var result = _db.MoodTrackers.Select(i => i.UserId == id);
            return _mapper.Map<IEnumerable<MoodTrackerDto>>(result);

        }
    }
}
