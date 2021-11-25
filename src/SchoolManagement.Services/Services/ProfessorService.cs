using AutoMapper;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _repository;
        private readonly IDisciplinaProfessorRepository _disciplinaProfrepository;

        public ProfessorService(IProfessorRepository repository, IDisciplinaProfessorRepository disciplinaProfrepository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._disciplinaProfrepository = disciplinaProfrepository;
        }

        public async Task<ProfessorDTO> Post(ProfessorDTO professorDTO)
        {
            Professor professor = new Professor(
                professorDTO.Nome,
                professorDTO.DataNascimento,
                professorDTO.RG,
                professorDTO.CPF,
                professorDTO.Sexo,
                professorDTO.Telefone,
                professorDTO.CTPS,
                professorDTO.Licenca,
                professorDTO.Titulacao,
                professorDTO.DataAdmissao
             );
            professor.Validate();

            var professorCreated = await _repository.Create(professor);
            foreach (var item in professorDTO.Disciplinas)
            {
                DisciplinaProfessor dp = new DisciplinaProfessor(professorCreated.Id, item.DisciplinaId, item.Dia, item.Horario);
                await _disciplinaProfrepository.Create(dp);
            }
            return _mapper.Map<ProfessorDTO>(professorCreated);
        }
        public async Task<ProfessorDTO> Update(ProfessorDTO professorDTO)
        {
            var professorExists = await _repository.Get(professorDTO.Id);

            if (professorExists == null)
                throw new DomainException("Não existe nenhum professor cadastrado com o id informado!!");

            var professor = _mapper.Map<Professor>(professorDTO);
            professor.Validate();

            var professorUpdated = await _repository.Update(professor);
            foreach (var item in professor.Disciplinas)
            {
                item.ProfessorId = professor.Id;
                var disciplinaProfessorUpdated = await _disciplinaProfrepository.Get(item.Id);

                if (disciplinaProfessorUpdated is null)
                {
                    item.Id = 0;
                    await _disciplinaProfrepository.Create(item);
                }
                else
                    await _disciplinaProfrepository.Update(item);
            }
            return _mapper.Map<ProfessorDTO>(professorUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<ProfessorDTO> Get(long id)
        {
            var professor = await _repository.Get(id);

            return _mapper.Map<ProfessorDTO>(professor);
        }

        public async Task<List<ProfessorDTO>> Get()
        {
            var allProfessores = await _repository.Get();

            return _mapper.Map<List<ProfessorDTO>>(allProfessores);
        }
    }
}
