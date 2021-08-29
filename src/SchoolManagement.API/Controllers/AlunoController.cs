using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Services.Interfaces;
using SchoolManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService service;

        public AlunoController(IAlunoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post(AlunoCreateViewModel aluno)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(service.Post(aluno));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
