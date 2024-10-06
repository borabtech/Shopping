
using Microsoft.EntityFrameworkCore;
using Shopping.Data.Database;
using Shopping.Data.Repository.Interfaces;
using Shopping.Data.Repository.Repositories;
using System.Text.Json.Serialization;

namespace Shopping.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("ShoppingConnectionString");
            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddTransient(typeof(IItemsRepository), typeof(ItemsRepository));

            builder.Services.AddControllers()
            .AddJsonOptions(opts =>
             {
                 var enumConverter = new JsonStringEnumConverter();
                 opts.JsonSerializerOptions.Converters.Add(enumConverter);
             });
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
