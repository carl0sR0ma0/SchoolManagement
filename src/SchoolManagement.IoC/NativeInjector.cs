using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Data.Repositories;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.Services;

namespace SchoolManagement.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            #endregion

            #region Repositories
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();            
            services.AddScoped<ITurmaRepository, TurmaRepository>();            
            services.AddScoped<IProfessorRepository, ProfessorRepository>();            
            #endregion
        }
    }
}
