using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TP24Receivables.API;
using TP24Receivables.Data;
using TP24Receivables.Data.Models;
using TP24Receivables.Logic.Models;
using TP24Receivables.Repository;

namespace TP24ReceivablesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.Configure<StatisticsConfig>(
                builder.Configuration.GetSection("StatisticsConfig")
            );
            
            var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");
            builder.Services.AddDbContext<ReceivablesDbContext>(options => 
                options.UseNpgsql(connectionString)
            );

            builder.Services.AddScoped<IDebtorRepository, DebtorRepository>();

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