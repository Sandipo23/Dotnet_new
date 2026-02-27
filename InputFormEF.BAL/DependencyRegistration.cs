using FluentValidation;
using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Interfaces;
using InputFormEF.BAL.Services;
using InputFormEF.BAL.Validator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL
{
    public static class DependencyRegistration
    {
        public static void AddBAL(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStudentReadService, StudentService>();
            services.AddScoped<IStudentWriteService, StudentService>();
            services.AddValidatorsFromAssemblyContaining<StudentCreateDtoValidator>();
            services.AddScoped<IValidator<LoginRequestDto>, LoginRequestDtoValidator>();
        }
    }
}