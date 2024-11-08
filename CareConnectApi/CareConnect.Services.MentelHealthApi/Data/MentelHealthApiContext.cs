using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CareConnect.Services.MentelHealthApi.Models;

    public class MentelHealthApiContext : DbContext
    {
        public MentelHealthApiContext (DbContextOptions<MentelHealthApiContext> options)
            : base(options)
        {
        }

        public DbSet<MoodTracker> MoodTracker { get; set; } = default!;
    }
