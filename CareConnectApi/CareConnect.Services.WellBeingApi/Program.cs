
using CareConnect.Services.MentelHealthApi.Configurations;
using CareConnect.Services.WellBeingApi.Services;
using CareConnect.Services.WellBeingApi.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace CareConnect.Services.WellBeingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SleepAnalyserApiContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("SleepAnalyserApiContext") ?? throw new InvalidOperationException("Connection string 'SleepAnalyser' not found.")));

            // Add services to the container.
            //Adding AutoMapper dependency 

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            builder.Services.AddTransient<ISleepAnalyserService, SleepAnalyserService>();
            builder.Services.AddScoped<ISleepAnalyserDtoService, SleepAnalyserDtoService>();

            //builder.Services.AddDbContext<SleepAnalyserApiContext>(options => options.serv

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
