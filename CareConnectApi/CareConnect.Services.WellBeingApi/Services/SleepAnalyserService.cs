using CareConnect.Services.WellBeingApi.Models;
using CareConnect.Services.WellBeingApi.Services.IService;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CareConnect.Services.WellBeingApi.Services
{
    public class SleepAnalyserService : ISleepAnalyserService
    {
        private readonly WellBeingApiContext _db;

        public SleepAnalyserService(WellBeingApiContext db)
        {
            _db = db;
        }

        public IEnumerable<SleepAnalyser> GetUserSleepLog(string userid)
        {

            try
            {
                var result = _db.SleepAnalyser
                    .Where(u => u.UserId == userid).ToList();

                return result; // 
            }
            catch (Exception ex)
            {
                // Log the exception (use a proper logging framework in production)
                Console.WriteLine($"Error retrieving sleep data for UserId: {userid}, Exception: {ex.Message}");
                return null; // Return null in case of failure
            }
        }

        public SleepAnalyser GetDataByUserDate(string userid, DateOnly date)// get by id and date . 
        {
            try
            {
                // Retrieve the sleep analysis data for the given user and date
                var result = _db.SleepAnalyser
                    .FirstOrDefault(u => u.DateTimeOfEntry == date && u.UserId == userid);

                return result; // Return the result (null if not found)
            }
            catch (Exception ex)
            {
                // Log the exception (use a proper logging framework in production)
                Console.WriteLine($"Error retrieving sleep data for UserId: {userid}, Date: {date}. Exception: {ex.Message}");
                return null; // Return null in case of failure
            }

        }




        public bool AddUserSleepLog(SleepAnalyser userSleepLog)
        {
            if (userSleepLog != null)
            {
                var result = _db.SleepAnalyser.FirstOrDefault(u => u.DateTimeOfEntry == userSleepLog.DateTimeOfEntry  && u.UserId == userSleepLog.UserId);
                if (result == null) {
                    _db.SleepAnalyser.Add(userSleepLog); _db.SaveChanges();
                    
                }
                else
                {
                    result.Rating = userSleepLog.Rating;
                    result.Remarks = userSleepLog.Remarks;
                    _db.SaveChanges(); 
                    return true;
                }

                    
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserSleepLog(int EntryId,string userid)
        {
            
                var result = _db.SleepAnalyser.FirstOrDefault(u => u.EntryId == EntryId && u.UserId==userid);
                if (result != null)
                {
                    _db.SleepAnalyser.Remove(result);
                  _db.SaveChanges();
                    return true;
                }
            
            return false;
        }   

      //  public bool UpdateUserSleepLog(SleepAnalyser sleep)
      //  {
      //      var result = _db.SleepAnalyser.FirstOrDefault(u => u.DateTimeOfEntry ==sleep.DateTimeOfEntry && u.UserId == sleep.UserId);

      //      if (result != null)
      //      {
      //          result.Rating = sleep.Rating;
      //          result.Remarks = sleep.Remarks;
      //          return true;
      //      }
      //      return false;

      //}

        
    }
}
