using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SaturdayDemo.Infrastructure.DataBase;
using Serilog;
using Serilog.Events;

namespace SaturdayDemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();


            var webHost = CreateWebHostBuilder(args).Build();
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var ServiceProvider = serviceScope.ServiceProvider;
                var loggerFactory = ServiceProvider.GetRequiredService<ILoggerFactory>();
                var myDbContext = ServiceProvider.GetRequiredService<MyDbContext>();
                MyDbContextSeed.SeedAsync(myDbContext, loggerFactory).Wait();
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();

    }
}
