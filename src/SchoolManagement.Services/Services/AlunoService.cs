﻿using AutoMapper;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<AlunoDTO> Post(AlunoDTO alunoDTO)
        {
            // Validação se existe um aluno com o mesmo RA.

            // Está dando erro no AutoMapper não sei porque, ele não está conseguindo instaciar uma nova classe Aluno e atribuir os atributos do AlunoDTO a classe Aluno.
            //var aluno = _mapper.Map<Aluno>(alunoDTO);
            // Por isso estou instanciando e atribuindo os atributos 'na mão' das respectivas classe, na tese o AutoMapper faz isso.
            Aluno aluno = new Aluno(
                alunoDTO.Nome,
                alunoDTO.DataNascimento,
                alunoDTO.RG, alunoDTO.CPF,
                alunoDTO.Sexo,
                alunoDTO.Telefone,
                alunoDTO.RA);

            aluno.Validate();

            var alunoCreated = await _repository.Create(aluno);
            return _mapper.Map<AlunoDTO>(alunoCreated);
        }
    }
}
