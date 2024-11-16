using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CareConnect.Services.WellBeingApi.Services
{
    public class ReminderSchedulerService : IReminderSchedulerService
    {
        private readonly WellBeingApiContext _db;

        public ReminderSchedulerService(WellBeingApiContext db)
        {
            _db = db;
        }

        public IEnumerable<ReminderScheduler> GetUserReminderLog()//get all 
        {
            return _db.ReminderScheduler.ToList();
        }

        public bool AddUserReminderLog(ReminderScheduler userReminderLog)
        {
            if (userReminderLog == null)
            {
                return false; // Return false if input is invalid
            }

            try
            {
                // Check if a matching record already exists
                var existingLog = _db.ReminderScheduler
                    .FirstOrDefault(u => u.DateTimeOfEntry == userReminderLog.DateTimeOfEntry && u.UserId == userReminderLog.UserId);

                if (existingLog == null)
                {
                    _db.ReminderScheduler.Add(userReminderLog);
                }
                else
                {
                    // Update the existing record
                   
                    existingLog.Task = userReminderLog.Task;
                    existingLog.Time = userReminderLog.Time;
                }

                // Save changes to the database
                _db.SaveChanges();

                return true; // Indicate success
            }
            catch (Exception ex)
            {
                // Log exception for debugging (replace with proper logging in production)
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Indicate failure
            }
        }

        public bool DeleteUserReminderLog(int id , DateOnly date)// delete .
        {
            if (date != DateOnly.MinValue)
            {
                var result = _db.ReminderScheduler.FirstOrDefault(u => u.DateTimeOfEntry == date && u.UserId == id);
                if (result != null)
                {
                    _db.ReminderScheduler.Remove(result);
                    return true;
                }
            }
            return false;
        }

       
    }
}
