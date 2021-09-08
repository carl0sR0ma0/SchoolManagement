using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _service;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateAlunoViewModel alunoViewModel)
        {
            try
            {
                var alunoDTO = _mapper.Map<AlunoDTO>(alunoViewModel);
                var alunoCreated = await _service.Post(alunoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Aluno criado com sucesso!",
                    Success = true,
                    Data = alunoCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<IActionResult> Put([FromBody] UpdateAlunoViewModel alunoViewModel)
        {
            try
            {
                var alunoDTO = _mapper.Map<AlunoDTO>(alunoViewModel);
                var alunoUpdated = await _service.Update(alunoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Aluno atualizado com sucesso!",
                    Success = true,
                    Data = alunoUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _service.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Aluno Removido com Sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/[controller]/get/{id}")]
        public async Task<IActionResult> GetOneAluno(long id)
        {
            try
            {
                var aluno = await _service.Get(id);

                if (aluno == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum aluno encontrado com o ID informado.",
                        Success = true,
                        Data = aluno
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Aluno Encontrado com sucesso!",
                    Success = true,
                    Data = aluno
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/[controller]/get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allAlunos = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Alunos encontrados com sucesso!",
                    Success = true,
                    Data = allAlunos
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/[controller]/get-by-ra")]
        public async Task<IActionResult> GetByRA([FromQuery] long ra)
        {
            try
            {
                var aluno = await _service.GetByRA(ra);

                if (aluno == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum aluno foi encontrado com o e-mail informado.",
                        Success = true,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Aluno encontrado com sucesso!",
                    Success = true,
                    Data = aluno
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
