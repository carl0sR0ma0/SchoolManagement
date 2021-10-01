using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.ColaboradorViewModel;
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
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorService _service;
        private readonly IMapper _mapper;

        public ColaboradorController(IColaboradorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateColaboradorViewModel colaboradorViewModel)
        {
            try
            {
                var colaboradorDTO = _mapper.Map<ColaboradorDTO>(colaboradorViewModel);
                var colaboradorCreated = await _service.Post(colaboradorDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Colaborador criado com sucesso!",
                    Success = true,
                    Data = colaboradorCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateColaboradorViewModel colaboradorViewModel)
        {
            try
            {
                var colaboradorDTO = _mapper.Map<ColaboradorDTO>(colaboradorViewModel);
                var colaboradorUpdated = await _service.Update(colaboradorDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Colaborador atualizado com sucesso!",
                    Success = true,
                    Data = colaboradorUpdated
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
                var colaborador = await _service.Get(id);

                if (colaborador == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum colaborador encontrado com o ID informado.",
                        Success = true,
                        Data = colaborador
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Colaborador Removido com Sucesso!",
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
        public async Task<IActionResult> GetOneColaborador(long id)
        {
            try
            {
                var colaborador = await _service.Get(id);

                if (colaborador == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum colaborador encontrado com o ID informado.",
                        Success = true,
                        Data = colaborador
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Colaborador Encontrado com sucesso!",
                    Success = true,
                    Data = colaborador
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
                var allColaboradores = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Colaboradores encontrados com sucesso!",
                    Success = true,
                    Data = allColaboradores
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
