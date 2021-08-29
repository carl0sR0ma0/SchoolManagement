using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Data.Repositories;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.Services;
using System;

namespace SchoolManagement.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAlunoService, AlunoService>();
            #endregion

            #region Repositories
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            #endregion
        }
    }
}
