using AutoMapper;
using CareConnect.Services.SafetyApi.Models;
using CareConnect.Services.SafetyApi.Services.IService;
using Microsoft.EntityFrameworkCore;


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


         public async Task<IEnumerable<ReportIncidentDto>> GetUserEventByDate(int id, DateOnly date)
        {
            try
            {
                var result = await _db.ReportIncident.Where(i => i.DateTimeOfEntry == date && i.UserId == id).ToListAsync();
                return _mapper.Map<IEnumerable<ReportIncidentDto>>(result);
            }
            catch
            {
                return null;
            }
        }

            public  async Task<IEnumerable<ReportIncidentDto>>GetUserEventData(int id)
            {
            try
            {
                var result = await _db.ReportIncident.Where(i => i.UserId == id).ToListAsync();
                return _mapper.Map<IEnumerable<ReportIncidentDto>>(result);
            }
            catch(Exception ex)
            {
                return null;
            }
            }
        }
    }
