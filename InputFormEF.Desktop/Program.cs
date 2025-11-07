using InputFormEF.BAL;

using InputFormEF.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using Microsoft.Extensions.DependencyInjection;

//using InputFormEF.DAL;

namespace InputFormEF.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run();
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 config
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             })
             .ConfigureServices((hostContext, services) =>
             {
                 IConfiguration configuration = hostContext.Configuration;
                 string connectionString = configuration["ConnectionStrings:DefaultConnection"];
                 services.AddDAL(connectionString);
                 services.AddBAL();
                 services.AddDestopLayer();
             });
    }
}