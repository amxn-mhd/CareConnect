
using CareConnect.Services.MentelHealthApi.Configurations;
using CareConnect.Services.SafetyApi.Services;
using CareConnect.Services.SafetyApi.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace CareConnect.Services.SafetyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SafetyApiContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("SafetyApiContext") ?? throw new InvalidOperationException("Connection string 'ReportIncident' not found.")));

            //builder.Services.AddDbContext<ReminderSchedulerApiContext>(options =>
            //   options.UseSqlServer(builder.Configuration.GetConnectionString("ReminderSchedulerApiContext") ?? throw new InvalidOperationException("Connection string 'SleepAnalyser' not found.")));

            // Add services to the container.
            //Adding AutoMapper dependency 

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

            builder.Services.AddTransient<IReportIncidentService, ReportIncidentService>();
            builder.Services.AddScoped<IReportIncidentDtoService, ReportIncidentDtoService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
