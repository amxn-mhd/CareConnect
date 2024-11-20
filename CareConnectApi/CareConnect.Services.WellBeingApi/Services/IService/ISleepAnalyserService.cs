using CareConnect.Services.WellBeingApi.Models;
using System;
using System.Collections.Generic;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface ISleepAnalyserService
    {
        IEnumerable<SleepAnalyser> GetUserSleepLog(string userid);//getAll(id)

        SleepAnalyser GetDataByUserDate(string userid,DateOnly date);//get(date)

        bool AddUserSleepLog(SleepAnalyser userSleepLog);

        //bool UpdateUserSleepLog(SleepAnalyser userSleepLog);

        bool DeleteUserSleepLog(int EntryId,string userid);
    }
}
