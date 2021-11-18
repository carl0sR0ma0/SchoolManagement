using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.MatriculaViewModel;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _service;
        private readonly IMapper _mapper;

        public MatriculaController(IMatriculaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateMatriculaViewModel matriculaViewModel)
        {
            try
            {
                var disciplinaDTO = _mapper.Map<List<DisciplinaMatriculadaDTO>>(matriculaViewModel.DisciplinaMatriculadas);
                var matriculaDTO = _mapper.Map<MatriculaDTO>(matriculaViewModel);
                matriculaDTO.DisciplinaMatriculadas = disciplinaDTO;
                var matriculaCreated = await _service.Post(matriculaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Matricula criada com sucesso!",
                    Success = true,
                    Data = matriculaCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateMatriculaViewModel matriculaViewModel)
        {
            try
            {
                var matriculaDTO = _mapper.Map<MatriculaDTO>(matriculaViewModel);
                var matriculaUpdated = await _service.Update(matriculaDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Matricula atualizada com sucesso!",
                    Success = true,
                    Data = matriculaUpdated
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
                var matricula = await _service.Get(id);

                if (matricula == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Matricula encontrada com o ID informado.",
                        Success = true,
                        Data = matricula
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Matricula Removida com Sucesso!",
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
        public async Task<IActionResult> GetOneMatricula(long id)
        {
            try
            {
                var matricula = await _service.Get(id);

                if (matricula == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Matricula encontrada com o ID informado.",
                        Success = true,
                        Data = matricula
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Matricula Encontrada com sucesso!",
                    Success = true,
                    Data = matricula
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
        [Route("/[controller]/getMatriculasByTurma/{turmaId}")]
        public async Task<IActionResult> GetMatriculasByTurma(long turmaId)
        {
            try
            {
                var matriculas = await _service.GetMatriculasByTurma(turmaId);

                if (matriculas.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma Matricula encontrada com o ID informado.",
                        Success = true,
                        Data = matriculas
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Matricula Encontrada com sucesso!",
                    Success = true,
                    Data = matriculas
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
                var allMatriculas = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Matriculas encontradas com sucesso!",
                    Success = true,
                    Data = allMatriculas
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
