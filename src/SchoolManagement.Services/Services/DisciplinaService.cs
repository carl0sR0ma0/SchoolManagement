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
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaRepository _repository;

        public DisciplinaService(IMapper mapper, IDisciplinaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DisciplinaDTO> Get(long id)
        {
            var disciplina = await _repository.Get(id);

            return _mapper.Map<DisciplinaDTO>(disciplina); 
        }

        public async Task<List<DisciplinaDTO>> Get()
        {
            var disciplinas = await _repository.Get();

            return _mapper.Map<List<DisciplinaDTO>>(disciplinas);
        }

        public async Task<DisciplinaDTO> Post(DisciplinaDTO disciplinaDTO)
        {
            Disciplina disciplina = new Disciplina(disciplinaDTO.Nome, disciplinaDTO.Sigla, disciplinaDTO.CargaHoraria, disciplinaDTO.ConteudoProgramatico, disciplinaDTO.Ementa, disciplinaDTO.AulasSemanais, disciplinaDTO.FaltasPermitidas);
            disciplina.Validate();

            var disciplinaCreated = await _repository.Create(disciplina);
            return _mapper.Map<DisciplinaDTO>(disciplinaCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<DisciplinaDTO> Update(DisciplinaDTO disciplinaDTO)
        {
            var disciplinaExists = await _repository.Get(disciplinaDTO.Id);

            if (disciplinaExists == null)
                throw new DomainException("Não existe nenhuma disciplina cadastrado com o Id informado!");

            var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);
            disciplina.Validate();

            var disciplinaUpdated = await _repository.Update(disciplina);
            return _mapper.Map<DisciplinaDTO>(disciplinaUpdated);
        }
    }
}
