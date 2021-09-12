using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.TurmaViewModel;
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
    public class TurmaController : Controller
    {
        private readonly ITurmaService _service;
        private readonly IMapper _mapper;

        public TurmaController(ITurmaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateTurmaViewModel turmaViewModel)
        {
            try
            {
                var turmaDTO = _mapper.Map<TurmaDTO>(turmaViewModel);
                var turmaCreated = await _service.Post(turmaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Turma criada com sucesso!",
                    Success = true,
                    Data = turmaCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateTurmaViewModel turmaViewModel)
        {
            try
            {
                var turmaDTO = _mapper.Map<TurmaDTO>(turmaViewModel);
                var turmaUpdated = await _service.Update(turmaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Turma atualizada com sucesso!",
                    Success = true,
                    Data = turmaUpdated
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
                var turma = await _service.Get(id);

                if (turma == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma turma encontrada com o ID informado.",
                        Success = true,
                        Data = turma
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Turma Removida com Sucesso!",
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
        public async Task<IActionResult> GetOneTurma(long id)
        {
            try
            {
                var turma = await _service.Get(id);

                if (turma == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma turma encontrada com o ID informado.",
                        Success = true,
                        Data = turma
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Turma Encontrada com sucesso!",
                    Success = true,
                    Data = turma
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
                var allTurmas = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Turmas encontradas com sucesso!",
                    Success = true,
                    Data = allTurmas
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
