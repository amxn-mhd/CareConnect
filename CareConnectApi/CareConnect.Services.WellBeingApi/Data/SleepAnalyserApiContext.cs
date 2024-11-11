using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using CareConnect.Services.MentelHealthApi.Models;
using CareConnect.Services.WellBeingApi.Models;

public class SleepAnalyserApiContext : DbContext
    {
        public SleepAnalyserApiContext (DbContextOptions<SleepAnalyserApiContext> options)
            : base(options)
        {
        }

        public DbSet<SleepAnalyser> SleepAnalyser { get; set; } = default!;
    }
