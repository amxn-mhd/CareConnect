using AutoMapper;
using CareConnect.Services.SafetyApi.Models;

namespace CareConnect.Services.MentelHealthApi.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap <ReportIncident, ReportIncidentDto>();
            //CreateMap<ReportIncident, ReminderSchedulerDto>();
        }
     
    }
}
