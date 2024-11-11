using AutoMapper;
using CareConnect.Services.WellBeingApi.Models;

namespace CareConnect.Services.MentelHealthApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap <SleepAnalyser, SleepAnalyserDto>();
        }
     
    }
}
