

using CareConnect.Services.WellBeingApi.Models;
using Microsoft.EntityFrameworkCore;

public class WellBeingApiContext : DbContext
    {
        public WellBeingApiContext (DbContextOptions<WellBeingApiContext> options)
            : base(options)
        {
        }

        public DbSet<SleepAnalyser> SleepAnalyser { get; set; } = default!;
    public DbSet<ReminderScheduler> ReminderScheduler { get; set; } = default!;
}
