using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.ProfessorViewModel;
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
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;
        private readonly IMapper _mapper;

        public ProfessorController(IProfessorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateProfessorViewModel professorViewModel)
        {
            try
            {
                var professorDTO = _mapper.Map<ProfessorDTO>(professorViewModel);
                var professorCreated = await _service.Post(professorDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Professor criado com sucesso!",
                    Success = true,
                    Data = professorCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateProfessorViewModel professorViewModel)
        {
            try
            {
                var professorDTO = _mapper.Map<ProfessorDTO>(professorViewModel);
                var professorUpdated = await _service.Update(professorDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Professor atualizado com sucesso!",
                    Success = true,
                    Data = professorUpdated
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
                var professor = await _service.Get(id);

                if (professor == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum professor encontrado com o ID informado.",
                        Success = true,
                        Data = professor
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Professor Removido com Sucesso!",
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
        public async Task<IActionResult> GetOneProfessor(long id)
        {
            try
            {
                var professor = await _service.Get(id);

                if (professor == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum professor encontrado com o ID informado.",
                        Success = true,
                        Data = professor
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Professor Encontrado com sucesso!",
                    Success = true,
                    Data = professor
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
                var allProfessores = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Professore encontrados com sucesso!",
                    Success = true,
                    Data = allProfessores
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
