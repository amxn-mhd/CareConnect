using CareConnect.Services.MentelHealthApi.Configurations;
using CareConnect.Services.MentelHealthApi.Services;
using CareConnect.Services.MentelHealthApi.Services.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CareConnect.Services.MentelHealthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MentelHealthApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MentelHealthApiContext") ?? throw new InvalidOperationException("Connection string 'MentelHealthApiContext' not found.")));

            // Add services to the container.

            //Adding AutoMapper dependency 

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            builder.Services.AddTransient<IMoodTrackerService , MoodTrackerService>();
            builder.Services.AddScoped<IMoodTrackerDtoService , MoodTrackerDtoService>();


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
            //seeding data to User interface Angular. 

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
