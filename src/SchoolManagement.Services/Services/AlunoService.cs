using AutoMapper;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IMapper mapper;
        private readonly IAlunoRepository repository;

        public AlunoService(IAlunoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public AlunoCreateViewModel Post(AlunoCreateViewModel aluno)
        {
            try
            {
                Aluno _aluno = mapper.Map<Aluno>(aluno);
                repository.Create(_aluno);
                return aluno;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
