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
                alunoDTO.RA,
                alunoDTO.CEP,
                alunoDTO.Logradouro,
                alunoDTO.Numero,
                alunoDTO.Bairro,
                alunoDTO.Cidade
            );

            aluno.Validate();

            var alunoCreated = await _repository.Create(aluno);
            return _mapper.Map<AlunoDTO>(alunoCreated);
        }
        public async Task<AlunoDTO> Update(AlunoDTO alunoDTO)
        {
            var alunoExists = await _repository.Get(alunoDTO.Id);

            if (alunoExists == null)
                throw new DomainException("Não existe nenhum aluno cadastrado com o id informado!!");

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.Validate();

            var alunoUpdated = await _repository.Update(aluno);
            return _mapper.Map<AlunoDTO>(alunoUpdated);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task<AlunoDTO> Get(long id)
        {
            var aluno = await _repository.Get(id);

            return _mapper.Map<AlunoDTO>(aluno);
        }

        public async Task<List<AlunoDTO>> Get()
        {
            var allAlunos = await _repository.Get();

            return _mapper.Map<List<AlunoDTO>>(allAlunos);
        }

        public async Task<AlunoDTO> GetByRA(long ra)
        {
            var aluno = await _repository.GetByRA(ra);

            return _mapper.Map<AlunoDTO>(aluno);
        }

    }
}
