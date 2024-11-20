using CareConnect.Services.SafetyApi.Models;
using CareConnect.Services.SafetyApi.Services.IService;
using Microsoft.EntityFrameworkCore;

//using CareConnect.Services.WellBeingApi.Models;
//using CareConnect.Services.WellBeingApi.Services.IService;
using System.Collections.Generic;

using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CareConnect.Services.SafetyApi.Services
{
    public class ReportIncidentService : IReportIncidentService
    {
        private readonly SafetyApiContext _db;

        public ReportIncidentService(SafetyApiContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ReportIncident>> GetUserReportLog()
        {
            try
            {
                return await _db.ReportIncident.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing data: {ex.Message}");

                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            return null;

        }

        public bool AddUserReportLog(ReportIncident userReportLog)
        {
            if (userReportLog != null)
            {

               
                    _db.ReportIncident.Add(userReportLog);
                    _db.SaveChanges();
                    return true;
                
               

            }
            return false;
        }


        // logic changes from hear. 


        bool IReportIncidentService.DeleteUserReportLog(int incidentId, string UserId)
        {
            try
            {

                var existingIncident = _db.ReportIncident
                                    .FirstOrDefault(i => i.IncidentId.Equals(incidentId) && i.UserId.Equals(UserId)); 
                if (existingIncident != null)
                    {
                        _db.ReportIncident.Remove(existingIncident);
                        _db.SaveChanges(); // Ensure changes are saved to the database
                        return true;
                    }
                

                return false; // No matching record found
            }
            catch (Exception ex)
            {
                // Log the exception for debugging (replace Console.WriteLine with proper logging in production)
                Console.WriteLine($"Error occurred while deleting report incident: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Optionally, rethrow or handle the exception further
                return false; // Indicate failure
            }
        }


        public bool UpdateUserReportLog( ReportIncident updatedIncident)

        {
            try
            {
                var existingIncident = _db.ReportIncident

                    .FirstOrDefault(i => i.IncidentId==updatedIncident.IncidentId && i.UserId.Equals(updatedIncident.UserId));

                if (existingIncident == null)
                {
                    return false;
                }

                if (!existingIncident.AuthorizeEdit)
                {
                    return false;
                }

                existingIncident.TypeOfAccident = updatedIncident.TypeOfAccident;
                existingIncident.Location = updatedIncident.Location;
                existingIncident.Time = updatedIncident.Time;
                existingIncident.ShortDescription = updatedIncident.ShortDescription;

                existingIncident.AuthorizeEdit = false;

                _db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


    }
}
