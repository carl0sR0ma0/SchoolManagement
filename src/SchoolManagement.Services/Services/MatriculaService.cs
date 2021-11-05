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
    public class MatriculaService : IMatriculaService
    {
        private readonly IMapper _mapper;
        private readonly IMatriculaRepository _repository;

        public MatriculaService(IMapper mapper, IMatriculaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MatriculaDTO> Get(long id)
        {
            var matricula = await _repository.Get(id);

            return _mapper.Map<MatriculaDTO>(matricula);
        }

        public async Task<List<MatriculaDTO>> Get()
        {
            var allMatriculas = await _repository.Get();

            return _mapper.Map<List<MatriculaDTO>>(allMatriculas);
        }

        public async Task<MatriculaDTO> GetByRA(long ra)
        {
            var matricula = await _repository.GetByRA(ra);

            return _mapper.Map<MatriculaDTO>(matricula);
        }

        public async Task<MatriculaDTO> Post(MatriculaDTO matriculaDTO)
        {
            Matricula matricula = new Matricula(
                matriculaDTO.Data,
                matriculaDTO.Situcao,
                matriculaDTO.Observacao,
                matriculaDTO.AlunoId,
                matriculaDTO.TurmaId
            );

            matricula.Validate();

            var matriculaCreated = await _repository.Create(matricula);
            return _mapper.Map<MatriculaDTO>(matriculaCreated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<MatriculaDTO> Update(MatriculaDTO matriculaDTO)
        {
            var matriculaExists = await _repository.Get(matriculaDTO.Id);

            if (matriculaExists == null)
                throw new DomainException("Não existe nenhum matricula cadastrada com o id informado!!");

            var matricula = _mapper.Map<Matricula>(matriculaDTO);
            matricula.Validate();

            var matriculaUpdated = await _repository.Update(matricula);
            return _mapper.Map<MatriculaDTO>(matriculaUpdated);
        }
    }
}
