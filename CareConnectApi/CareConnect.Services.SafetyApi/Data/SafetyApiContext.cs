

using CareConnect.Services.SafetyApi.Models;
using Microsoft.EntityFrameworkCore;

public class SafetyApiContext : DbContext
    {
        public SafetyApiContext (DbContextOptions<SafetyApiContext> options)
            : base(options)
        {
        }

        public DbSet<ReportIncident> ReportIncident { get; set; } = default!;
    
}
