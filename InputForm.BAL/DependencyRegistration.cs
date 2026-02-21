using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.BAL
{
    public static class DependencyRegistration
    {
        public static void AddBAL(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStudentReadService, StudentService>();
            services.AddScoped<IStudentWriteService, StudentService>();
        }
    }
}