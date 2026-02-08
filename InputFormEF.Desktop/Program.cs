using InputFormEF.BAL;

using InputFormEF.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Server;
using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1;

//using InputFormEF.DAL;

namespace InputFormEF.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ServiceProvider = host.Services;

            ApplicationConfiguration.Initialize();
            var loginForm = ServiceProvider.GetService<LoginForm>();
            Application.Run(loginForm);
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