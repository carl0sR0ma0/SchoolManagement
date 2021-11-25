using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.DisciplinaMatriculadaViewModel;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    public class DisciplinaProfessorController : Controller
    {
        private readonly IDisciplinaProfessorService _service;
        private readonly IMapper _mapper;

        public DisciplinaProfessorController(IDisciplinaProfessorService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateDisciplinaProfessorViewModel disciplinaViewModel)
        {
            try
            {
                var disciplinaMatriculadaDTO = _mapper.Map<DisciplinaProfessorDTO>(disciplinaViewModel);
                var disciplinaCreated = await _service.Post(disciplinaMatriculadaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina criada com sucesso!",
                    Success = true,
                    Data = disciplinaCreated
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

        //[HttpPut]
        //[Route("/[controller]/update")]
        //public async Task<IActionResult> Put([FromBody] UpdateDisciplinaViewModel disciplinaViewModel)
        //{
        //    try
        //    {
        //        var disciplinaMatriculadaDTO = _mapper.Map<DisciplinaDTO>(disciplinaViewModel);
        //        var disciplinaUpdated = await _service.Update(disciplinaDTO);

        //        return Ok(new ResultViewModel
        //        {
        //            Message = "Disciplina atualizada com sucesso!",
        //            Success = true,
        //            Data = disciplinaUpdated
        //        });
        //    }
        //    catch (DomainException ex)
        //    {
        //        return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, Responses.ApplicationErrorMessage());
        //    }
        //}

        [HttpDelete]
        [Route("/[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var disciplina = await _service.Get(id);

                if (disciplina == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Disciplina encontrada com o ID informado.",
                        Success = true,
                        Data = disciplina
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Removida com Sucesso!",
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
        public async Task<IActionResult> GetOneDisciplina(long id)
        {
            try
            {
                var disciplina = await _service.Get(id);

                if (disciplina == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Disciplina encontrada com o ID informado.",
                        Success = true,
                        Data = disciplina
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Encontrada com sucesso!",
                    Success = true,
                    Data = disciplina
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
        [Route("/[controller]/getdisciplinaprofessorByProfessor/{professorId}")]
        public async Task<IActionResult> GetDisciplinaProfessorByProfessor(long professorId)
        {
            try
            {
                var disciplina = await _service.GetDisciplinasByProfessor(professorId);

                if (disciplina == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Disciplina encontrada com o ID informado.",
                        Success = true,
                        Data = disciplina
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Encontrada com sucesso!",
                    Success = true,
                    Data = disciplina
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
        [Route("/[controller]/getdisciplinaprofessorByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetDisciplinaProfessorByDisciplina(long disciplinaId)
        {
            try
            {
                var disciplina = await _service.GetProfessorByDisciplina(disciplinaId);

                if (disciplina == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Disciplina encontrada com o ID informado.",
                        Success = true,
                        Data = disciplina
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Disciplina Encontrada com sucesso!",
                    Success = true,
                    Data = disciplina
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
                var allDisciplinas = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Disciplinas encontradas com sucesso!",
                    Success = true,
                    Data = allDisciplinas
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

