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
    public class ColaboradorService : IColaboradorService
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ColaboradorDTO> Post(ColaboradorDTO colaboradorDTO)
        {
           
            Colaborador colaborador = new Colaborador(
                colaboradorDTO.Nome,
                colaboradorDTO.DataNascimento,
                colaboradorDTO.RG,
                colaboradorDTO.CPF,
                colaboradorDTO.Sexo,
                colaboradorDTO.Telefone,
                colaboradorDTO.Ctps,
                colaboradorDTO.Cargo,
                colaboradorDTO.DataAdmissao);



            colaborador.Validate();

            var colaboradorCreated = await _repository.Create(colaborador);
            return _mapper.Map<ColaboradorDTO>(colaboradorCreated);
        }
        public async Task<ColaboradorDTO> Update(ColaboradorDTO colaboradorDTO)
        {
            var colaboradorExists = await _repository.Get(colaboradorDTO.Id);

            if (colaboradorExists == null)
                throw new DomainException("Não existe nenhum colaborador cadastrado com o id informado!!");

            var colaborador = _mapper.Map<Colaborador>(colaboradorDTO);
            colaborador.Validate();

            var colaboradorUpdated = await _repository.Update(colaborador);
            return _mapper.Map<ColaboradorDTO>(colaboradorUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<ColaboradorDTO> Get(long id)
        {
            var colaborador = await _repository.Get(id);

            return _mapper.Map<ColaboradorDTO>(colaborador);
        }

        public async Task<List<ColaboradorDTO>> Get()
        {
            var allColaboradores = await _repository.Get();

            return _mapper.Map<List<ColaboradorDTO>>(allColaboradores);
        }
    }
}
