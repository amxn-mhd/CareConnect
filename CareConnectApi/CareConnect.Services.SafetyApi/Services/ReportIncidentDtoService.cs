using AutoMapper;
using CareConnect.Services.SafetyApi.Models;
using CareConnect.Services.SafetyApi.Services.IService;


namespace CareConnect.Services.SafetyApi.Services
{
    
        public class ReportIncidentDtoService : IReportIncidentDtoService
        {
            private readonly SafetyApiContext _db;
            private readonly IMapper _mapper;

            public ReportIncidentDtoService(IMapper mapper, SafetyApiContext reportIncidentApiContext)
            {
                _mapper = mapper;
                _db = reportIncidentApiContext;
            }

            public ReportIncidentDto MapSourceToDestination(ReportIncident reportIncident)
            {
                return _mapper.Map<ReportIncidentDto>(reportIncident);
            }
            public IEnumerable<ReportIncidentDto> GetUserReport()
            {
                var result = _db.ReportIncident.ToList();
                return _mapper.Map<IEnumerable<ReportIncidentDto>>(result);
            }




            public ReportIncidentDto GetUserReportByDate(DateOnly date)
            {
                var result = _db.ReportIncident.FirstOrDefault(i => i.DateTimeOfEntry == date);
                return _mapper.Map<ReportIncidentDto>(result);
            }

            public IEnumerable<ReportIncidentDto> GetUserReportByID(int id)
            {
                var result = _db.ReportIncident.Select(i => i.UserId == id);
                return _mapper.Map<IEnumerable<ReportIncidentDto>>(result);

            }
        }
    }
