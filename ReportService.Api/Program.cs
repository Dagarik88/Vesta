using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ReportService.Api
{
#pragma warning disable 1591
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(wb => wb.UseShutdownTimeout(TimeSpan.FromSeconds(10))
                    .UseStartup<Startup>())
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                });
    }
#pragma warning restore 1591
}