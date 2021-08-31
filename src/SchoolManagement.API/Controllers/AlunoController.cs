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
    }
}
