using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.DisciplinaViewModel;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    public class NotaController : Controller
    {
        private readonly INotaService _service;
        private readonly IMapper _mapper;

        public NotaController(INotaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateNotaViewModel notaViewModel)
        {
            try
            {
                var notaDTO = _mapper.Map<NotaDTO>(notaViewModel);
                var notaCreated = await _service.Post(notaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Nota criada com sucesso!",
                    Success = true,
                    Data = notaCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateNotaViewModel notaViewModel)
        {
            try
            {
                var notaDTO = _mapper.Map<NotaDTO>(notaViewModel);
                var notaUpdated = await _service.Update(notaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Nota atualizada com sucesso!",
                    Success = true,
                    Data = notaUpdated
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
        [Route("/[controller]/delete/{turmaId}/{disciplinaId}/{alunoId}")]
        public async Task<IActionResult> Delete(long turmaId, long disciplinaId, long alunoId)
        {
            try
            {
                var nota = await _service.GetNotasByAlunoDisciplina(alunoId, disciplinaId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }
                await _service.Remove(turmaId, disciplinaId, alunoId);
                return Ok(new ResultViewModel
                {
                    Message = "Nota Removida com Sucesso!",
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
        [Route("/[controller]/get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allNotas = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Notas encontradas com sucesso!",
                    Success = true,
                    Data = allNotas
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
        [Route("/[controller]/getByAluno/{alunoId}")]
        public async Task<IActionResult> GetNotaByAluno(long alunoId)
        {
            try
            {
                var nota = await _service.GetNotasByAluno(alunoId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota Encontrada com sucesso!",
                    Success = true,
                    Data = nota
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
        [Route("/[controller]/getByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetNotaByDisciplina(long disciplinaId)
        {
            try
            {
                var nota = await _service.GetNotasByDisciplina(disciplinaId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota Encontrada com sucesso!",
                    Success = true,
                    Data = nota
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
        [Route("/[controller]/getByAlunoDisciplina/{alunoId}/{disciplinaId}")]
        public async Task<IActionResult> GetNotaByAlunoDisciplina(long alunoId, long disciplinaId)
        {
            try
            {
                var nota = await _service.GetNotasByAlunoDisciplina(alunoId, disciplinaId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota Encontrada com sucesso!",
                    Success = true,
                    Data = nota
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
        [Route("/[controller]/getByTurmaDisciplina/{turmaId}/{disciplinaId}")]
        public async Task<IActionResult> GetNotasByTurmaDisciplina(long turmaId, long disciplinaId)
        {
            try
            {
                var nota = await _service.GetNotasByTurmaDisciplina(turmaId, disciplinaId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota Encontrada com sucesso!",
                    Success = true,
                    Data = nota
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
        [Route("/[controller]/getByTurmaAluno/{turmaId}/{alunoId}")]
        public async Task<IActionResult> GetNotasByTurmaAluno(long turmaId, long alunoId)
        {
            try
            {
                var nota = await _service.GetNotasByTurmaAluno(turmaId, alunoId);

                if (nota == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Nota encontrada com o ID informado.",
                        Success = true,
                        Data = nota
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Nota Encontrada com sucesso!",
                    Success = true,
                    Data = nota
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