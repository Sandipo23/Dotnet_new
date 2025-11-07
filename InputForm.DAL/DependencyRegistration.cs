using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.DAL
{
    public static class DependencyRegistration
    {
        public static void AddDAL(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IDapperRepository>(x => new DapperRepository(connectionString));
            services.AddScoped<IStudentReadRepository, StudentRepository>();
            services.AddScoped<IStudentWriteRepository, StudentRepository>();
        }
    }
}