using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Data.Repositories;
using SchoolManagement.Domain.Interfaces;
using System;

namespace SchoolManagement.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            #endregion
        }
    }
}
