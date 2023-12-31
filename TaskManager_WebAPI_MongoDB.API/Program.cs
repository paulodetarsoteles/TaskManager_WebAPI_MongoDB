using Microsoft.Extensions.Options;
using TaskManager_WebAPI_MongoDB.DAL.Data;
using TaskManager_WebAPI_MongoDB.DAL.Data.Interfaces;
using TaskManager_WebAPI_MongoDB.DAL.Repositories;
using TaskManager_WebAPI_MongoDB.DAL.Repositories.Interfaces;

namespace TaskManager_WebAPI_MongoDB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<DbSetting>(builder.Configuration.GetSection("ConnectionStrings"));
            builder.Services.AddSingleton<IDbSetting>(dbs => dbs.GetRequiredService<IOptions<DbSetting>>().Value);

            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}