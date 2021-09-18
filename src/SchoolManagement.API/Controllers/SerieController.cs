using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Utilities;
using SchoolManagement.API.ViewModel;
using SchoolManagement.API.ViewModel.SerieViewModel;
using SchoolManagement.Services.DTO;
using SchoolManagement.Services.Interfaces;
using SchoolManager.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService _service;
        private readonly IMapper _mapper;

        public SerieController(ISerieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[controller]/create")]
        public async Task<IActionResult> Post([FromBody] CreateSerieViewModel serieViewModel)
        {
            try
            {
                var serieDTO = _mapper.Map<SerieDTO>(serieViewModel);
                var serieCreated = await _service.Post(serieDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Série criada com sucesso!",
                    Success = true,
                    Data = serieCreated
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
        public async Task<IActionResult> Put([FromBody] UpdateSerieViewModel serieViewModel)
        {
            try
            {
                var serieDTO = _mapper.Map<SerieDTO>(serieViewModel);
                var serieUpdated = await _service.Update(serieDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Série atualizada com sucesso!",
                    Success = true,
                    Data = serieUpdated
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
                var serie = await _service.Get(id);

                if (serie == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma serie encontrado com o ID informado.",
                        Success = true,
                        Data = serie
                    });
                }
                await _service.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Série Removida com Sucesso!",
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
        public async Task<IActionResult> GetOneSerie(long id)
        {
            try
            {
                var serie = await _service.Get(id);

                if (serie == null)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma série encontrada com o ID informado.",
                        Success = true,
                        Data = serie
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Série encontrada com sucesso!",
                    Success = true,
                    Data = serie
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
        [Route("/[controller]/get-by-course/{cursoId}")]
        public async Task<IActionResult> GetSeriesByCourse(long cursoId)
        {
            try
            {
                var allSeries = await _service.GetSeriesByCourse(cursoId);

                if (allSeries.Count == 0)
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma série encontrada com o ID informado.",
                        Success = true,
                        Data = allSeries
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Séries encontradas com sucesso!",
                    Success = true,
                    Data = allSeries
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
                var allSeries = await _service.Get();

                return Ok(new ResultViewModel
                {
                    Message = "Série encontradas com sucesso!",
                    Success = true,
                    Data = allSeries
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
