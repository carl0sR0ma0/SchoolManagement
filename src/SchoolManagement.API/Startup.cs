using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.CursoViewModel;
using SchoolManagement.API.ViewModel.SerieViewModel;
using SchoolManagement.API.ViewModel.ProfessorViewModel;
using SchoolManagement.API.ViewModel.ColaboradorViewModel;
using SchoolManagement.API.ViewModel.TurmaViewModel;
using SchoolManagement.Data.ORM;
using SchoolManagement.Domain.Models;
using SchoolManagement.IoC;
using SchoolManagement.Services.DTO;
using Newtonsoft.Json;
using SchoolManagement.API.ViewModel.DisciplinaViewModel;
using SchoolManagement.API.ViewModel.MatriculaViewModel;
using SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel;

namespace SchoolManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aluno, AlunoDTO>().ReverseMap();
                cfg.CreateMap<CreateAlunoViewModel, AlunoDTO>().ReverseMap();
                cfg.CreateMap<UpdateAlunoViewModel, AlunoDTO>().ReverseMap();

                cfg.CreateMap<Curso, CursoDTO>().ReverseMap();
                cfg.CreateMap<CreateCursoViewModel, CursoDTO>().ReverseMap();
                cfg.CreateMap<UpdateCursoViewModel, CursoDTO>().ReverseMap();
                
                cfg.CreateMap<Serie, SerieDTO>().ReverseMap();
                cfg.CreateMap<CreateSerieViewModel, SerieDTO>().ReverseMap();
                cfg.CreateMap<UpdateSerieViewModel, SerieDTO>().ReverseMap();

                cfg.CreateMap<Turma, TurmaDTO>().ReverseMap();
                cfg.CreateMap<CreateTurmaViewModel, TurmaDTO>().ReverseMap();
                cfg.CreateMap<UpdateTurmaViewModel, TurmaDTO>().ReverseMap();

                cfg.CreateMap<Professor, ProfessorDTO>().ReverseMap();
                cfg.CreateMap<CreateProfessorViewModel, ProfessorDTO>().ReverseMap();
                cfg.CreateMap<UpdateProfessorViewModel, ProfessorDTO>().ReverseMap();

                cfg.CreateMap<Colaborador, ColaboradorDTO>().ReverseMap();
                cfg.CreateMap<CreateColaboradorViewModel, ColaboradorDTO>().ReverseMap();
                cfg.CreateMap<UpdateColaboradorViewModel, ColaboradorDTO>().ReverseMap();

                cfg.CreateMap<Disciplina, DisciplinaDTO>().ReverseMap();
                cfg.CreateMap<CreateDisciplinaViewModel, DisciplinaDTO>().ReverseMap();
                cfg.CreateMap<UpdateDisciplinaViewModel, DisciplinaDTO>().ReverseMap();
                
                cfg.CreateMap<Matricula, MatriculaDTO>().ReverseMap();
                cfg.CreateMap<CreateMatriculaViewModel, MatriculaDTO>().ReverseMap();
                cfg.CreateMap<UpdateMatriculaViewModel, MatriculaDTO>().ReverseMap();
                
                cfg.CreateMap<DisciplinaProfessor, DisciplinaProfessorDTO>().ReverseMap();
                cfg.CreateMap<CreateDisciplinaProfessorViewModel, DisciplinaProfessorDTO>().ReverseMap();
                cfg.CreateMap<DisciplinaProfessorViewModel, MatriculaDTO>().ReverseMap();
                
                cfg.CreateMap<DisciplinaMatriculada, DisciplinaMatriculadaDTO>().ReverseMap();
                cfg.CreateMap<CreateDisciplinaMatriculadaViewModel, DisciplinaMatriculadaDTO>().ReverseMap();
                cfg.CreateMap<UpdateDisciplinaMatriculadaViewModel, DisciplinaMatriculadaDTO>().ReverseMap();
                
                cfg.CreateMap<Nota, NotaDTO>().ReverseMap();
                cfg.CreateMap<CreateNotaViewModel, NotaDTO>().ReverseMap();
                cfg.CreateMap<UpdateNotaViewModel, NotaDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolManagement.API", Version = "v1" });
            });
            services.AddDbContext<SchoolManagementContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SchoolDB")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            NativeInjector.RegisterServices(services);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
