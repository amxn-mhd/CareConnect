using AutoMapper;
using CareConnect.Services.MentelHealthApi.Models;

namespace CareConnect.Services.MentelHealthApi.Configurations
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<MoodTracker, MoodTrackerDto>();
        }
     
    }
}
