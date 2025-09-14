using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using InputForm.BAL;
using InputForm.DAL;

namespace WinFormsApp1
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

                 // Presentation
                 services.AddScoped<LoginForm>();
                 services.AddScoped<StudentForm>();

                 // BAL
                 services.AddScoped<ILoginService, LoginService>();
                 services.AddScoped<IStudentReadService, StudentService>();
                 services.AddScoped<IStudentWriteService, StudentService>();

                 // DAL
                 services.AddScoped<ILoginRepository, LoginRepository>();
                 services.AddScoped<IDapperRepository>(x => new DapperRepository(connectionString));
                 services.AddScoped<IStudentReadRepository, StudentRepository>();
                 services.AddScoped<IStudentWriteRepository, StudentRepository>();
             });
    }
}