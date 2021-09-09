using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.CursoViewModel;
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
    public class CursoController : Controller
    {
        private readonly ICursoService _service;
        private readonly IMapper _mapper;

        public CursoController(ICursoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateCursoViewModel cursoViewModel)
        {
            try
            {
                var cursoDTO = _mapper.Map<CursoDTO>(cursoViewModel);
                var cursoCreated = await _service.Post(cursoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Curso criado com sucesso!",
                    Success = true,
                    Data = cursoCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateCursoViewModel cursoViewModel)
        {
            try
            {
                var cursoDTO = _mapper.Map<CursoDTO>(cursoViewModel);
                var cursoUpdated = await _service.Update(cursoDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Curso atualizado com sucesso!",
                    Success = true,
                    Data = cursoUpdated
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
                var curso = await _service.Get(id);

                if (curso == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum curso encontrado com o ID informado.",
                        Success = true,
                        Data = curso
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Curso Removido com Sucesso!",
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
        public async Task<IActionResult> GetOneCurso(long id)
        {
            try
            {
                var curso = await _service.Get(id);

                if (curso == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum curso encontrado com o ID informado.",
                        Success = true,
                        Data = curso
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Curso Encontrado com sucesso!",
                    Success = true,
                    Data = curso
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
                var allCursos = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Cursos encontrados com sucesso!",
                    Success = true,
                    Data = allCursos
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
