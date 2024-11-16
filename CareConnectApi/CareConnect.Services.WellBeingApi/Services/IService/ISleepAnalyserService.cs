using CareConnect.Services.WellBeingApi.Models;
using System;
using System.Collections.Generic;

namespace CareConnect.Services.WellBeingApi.Services.IService
{
    public interface ISleepAnalyserService
    {
        IEnumerable<SleepAnalyser> GetUserSleepLog(int userid);//getAll(id)

        SleepAnalyser GetDataByUserDate(int userid,DateOnly date);//get(date)

        bool AddUserSleepLog(SleepAnalyser userSleepLog);

        //bool UpdateUserSleepLog(SleepAnalyser userSleepLog);

        bool DeleteUserSleepLog(int userid,DateOnly date);
    }
}
