﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace InputForm.Desktop
{
    public static class DependencyRegistration
    {
        public static void AddDestopLayer(this IServiceCollection services)
        {
            services.AddScoped<LoginForm>();
            services.AddScoped<StudentForm>();
        }
    }
}