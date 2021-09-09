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
    public class CursoService : ICursoService
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepository _repository;

        public CursoService(IMapper mapper, ICursoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CursoDTO> Get(long id)
        {
            var curso = await _repository.Get(id);

            return _mapper.Map<CursoDTO>(curso); 
        }

        public async Task<List<CursoDTO>> Get()
        {
            var cursos = await _repository.Get();

            return _mapper.Map<List<CursoDTO>>(cursos);
        }

        public async Task<CursoDTO> Post(CursoDTO cursoDTO)
        {
            Curso curso = new Curso(cursoDTO.Nome, cursoDTO.SerieIni, cursoDTO.SerieFin, cursoDTO.Coordenador);
            curso.Validate();

            var cursoCreated = await _repository.Create(curso);
            return _mapper.Map<CursoDTO>(cursoCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<CursoDTO> Update(CursoDTO cursoDTO)
        {
            var cursoExists = await _repository.Get(cursoDTO.Id);

            if (cursoExists == null)
                throw new DomainException("Não existe nenhum Curso cadastrado com o Id informado!");

            var curso = _mapper.Map<Curso>(cursoDTO);
            curso.Validate();

            var cursoUpdated = await _repository.Update(curso);
            return _mapper.Map<CursoDTO>(cursoUpdated);
        }
    }
}
