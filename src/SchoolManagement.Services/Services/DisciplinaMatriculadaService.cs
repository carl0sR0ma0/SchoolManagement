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
    public class DisciplinaMatriculadaService : IDisciplinaMatriculadaService
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaMatriculadaRepository _repository;

        public DisciplinaMatriculadaService(IMapper mapper, IDisciplinaMatriculadaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DisciplinaMatriculadaDTO> Get(long id)
        {
            var disciplina = await _repository.Get(id);

            return _mapper.Map<DisciplinaMatriculadaDTO>(disciplina);
        }

        public async Task<List<DisciplinaMatriculadaDTO>> Get()
        {
            var disciplinas = await _repository.Get();

            return _mapper.Map<List<DisciplinaMatriculadaDTO>>(disciplinas);
        }

        public async Task<DisciplinaMatriculadaDTO> Post(DisciplinaMatriculadaDTO disciplinaDTO)
        {
            DisciplinaMatriculada disciplina = new DisciplinaMatriculada(
                disciplinaDTO.DisicplinaProfessorId, disciplinaDTO.MatriculaId, disciplinaDTO.Horario);
            disciplina.Validate();

            var disciplinaCreated = await _repository.Create(disciplina);
            return _mapper.Map<DisciplinaMatriculadaDTO>(disciplinaCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<DisciplinaMatriculadaDTO> Update(DisciplinaMatriculadaDTO disciplinaDTO)
        {
            var disciplinaExists = await _repository.Get(disciplinaDTO.Id);

            if (disciplinaExists == null)
                throw new DomainException("Não existe nenhuma disciplina cadastrado com o Id informado!");

            var disciplina = _mapper.Map<DisciplinaMatriculada>(disciplinaDTO);
            disciplina.Validate();

            var disciplinaUpdated = await _repository.Update(disciplina);
            return _mapper.Map<DisciplinaMatriculadaDTO>(disciplinaUpdated);
        }
    }
}
