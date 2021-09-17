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
    public class TurmaService : ITurmaService
    {
        private readonly IMapper _mapper;
        private readonly ITurmaRepository _repository;

        public TurmaService(IMapper mapper, ITurmaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TurmaDTO> Get(long id)
        {
            var turma = await _repository.Get(id);

            return _mapper.Map<TurmaDTO>(turma); 
        }

        public async Task<List<TurmaDTO>> Get()
        {
            var turmas = await _repository.Get();

            return _mapper.Map<List<TurmaDTO>>(turmas);
        }

        public async Task<TurmaDTO> Post(TurmaDTO turmaDTO)
        {
            Turma turma = new Turma(turmaDTO.Nome, turmaDTO.Turno, turmaDTO.Ano, turmaDTO.QtdAlunos, turmaDTO.Sigla, turmaDTO.Situacao);
            turma.Validate();

            var turmaCreated = await _repository.Create(turma);
            return _mapper.Map<TurmaDTO>(turmaCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<TurmaDTO> Update(TurmaDTO turmaDTO)
        {
            var turmaExists = await _repository.Get(turmaDTO.Id);

            if (turmaExists == null)
                throw new DomainException("Não existe nenhuma Turma cadastrada com o Id informado!");

            var turma = _mapper.Map<Turma>(turmaDTO);
            turma.Validate();

            var turmaUpdated = await _repository.Update(turma);
            return _mapper.Map<TurmaDTO>(turmaUpdated);
        }
    }
}
