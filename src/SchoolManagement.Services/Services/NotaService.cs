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
    public class NotaService : INotaService
    {
        private readonly IMapper _mapper;
        private readonly INotasRepository _repository;

        public NotaService(IMapper mapper, INotasRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<NotaDTO>> Get()
        {
            var notas = await _repository.Get();
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<List<NotaDTO>> GetNotasByAluno(long alunoId)
        {
            var notas = await _repository.GetNotasByAluno(alunoId);
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<List<NotaDTO>> GetNotasByAlunoDisciplina(long alunoId, long disciplinaId)
        {
            var notas = await _repository.GetNotasByAlunoDisciplina(alunoId, disciplinaId);
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<List<NotaDTO>> GetNotasByDisciplina(long disciplinaId)
        {
            var notas = await _repository.GetNotasByDisciplina(disciplinaId);
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<List<NotaDTO>> GetNotasByTurmaAluno(long turmaId, long alunoId)
        {
            var notas = await _repository.GetNotasByTurmaAluno(turmaId, alunoId);
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<List<NotaDTO>> GetNotasByTurmaDisciplina(long turmaId, long disciplinaId)
        {
            var notas = await _repository.GetNotasByTurmaDisciplina(turmaId, disciplinaId);
            return _mapper.Map<List<NotaDTO>>(notas);
        }

        public async Task<NotaDTO> Post(NotaDTO notaDTO)
        {
            Nota nota = new Nota(
                notaDTO.AlunoId,
                notaDTO.DisciplinaId,
                notaDTO.TurmaId,
                notaDTO.Nota1,
                notaDTO.Nota2,
                notaDTO.Nota3,
                notaDTO.Nota4,
                notaDTO.Media,
                notaDTO.AprovadoReprovado
            );

            var notaCreated = await _repository.Create(nota);
            return _mapper.Map<NotaDTO>(notaCreated);
        }

        public async Task Remove(long turmaId, long disciplinaId, long alunoId)
        {
            await _repository.Remove(turmaId, disciplinaId, alunoId);
        }

        public async Task<NotaDTO> Update(NotaDTO notaDTO)
        {
            var notaExists = await _repository.GetNotasByAlunoDisciplina(notaDTO.AlunoId, notaDTO.DisciplinaId);

            if (notaExists == null)
                throw new DomainException("Não existe nenhuma nota cadastrada com o Id informado!");

            var nota = _mapper.Map<Nota>(notaDTO);

            var notaUpdated = await _repository.Update(nota);
            return _mapper.Map<NotaDTO>(notaUpdated);
        }
    }
}
