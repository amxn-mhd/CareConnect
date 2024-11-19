using AutoMapper;
using CareConnect.Services.WellBeingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CareConnect.Services.MentelHealthApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ReminderScheduler, ReminderSchedulerDto>();
        }
     
    }
}
