using AutoMapper;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Services
{
    public class DisciplinaProfessorService : IDisciplinaProfessorService
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaProfessorRepository _repository;

        public DisciplinaProfessorService(IMapper mapper, IDisciplinaProfessorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DisciplinaProfessorDTO> Get(long id)
        {
            var disciplina = await _repository.Get(id);

            return _mapper.Map<DisciplinaProfessorDTO>(disciplina);
        }

        public async Task<List<DisciplinaProfessorDTO>> GetDisciplinasByProfessor(long professorId)
        {
            var disciplinas = await _repository.GetDisciplinasByProfessor(professorId);

            return _mapper.Map<List<DisciplinaProfessorDTO>>(disciplinas);
        }

        public async Task<List<DisciplinaProfessorDTO>> GetProfessorByDisciplina(long disciplinaId)
        {
            var disciplinas = await _repository.GetProfessorByDisciplina(disciplinaId);

            return _mapper.Map<List<DisciplinaProfessorDTO>>(disciplinas);
        }

        public async Task<List<DisciplinaProfessorDTO>> Get()
        {
            var disciplinas = await _repository.Get();

            return _mapper.Map<List<DisciplinaProfessorDTO>>(disciplinas);
        }

        public async Task<DisciplinaProfessorDTO> Post(DisciplinaProfessorDTO disciplinaDTO)
        {
            DisciplinaProfessor disciplina = new DisciplinaProfessor(
                disciplinaDTO.ProfessorId, disciplinaDTO.DisciplinaId, disciplinaDTO.Dia, disciplinaDTO.Horario);
            disciplina.Validate();

            var disciplinaCreated = await _repository.Create(disciplina);
            return _mapper.Map<DisciplinaProfessorDTO>(disciplinaCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<DisciplinaProfessorDTO> Update(DisciplinaProfessorDTO disciplinaDTO)
        {
            var disciplinaExists = await _repository.Get(disciplinaDTO.Id);

            if (disciplinaExists == null)
                throw new DomainException("Não existe nenhuma disciplina cadastrado com o Id informado!");

            var disciplina = _mapper.Map<DisciplinaProfessor>(disciplinaDTO);
            disciplina.Validate();

            var disciplinaUpdated = await _repository.Update(disciplina);
            return _mapper.Map<DisciplinaProfessorDTO>(disciplinaUpdated);
        }
    }
}
