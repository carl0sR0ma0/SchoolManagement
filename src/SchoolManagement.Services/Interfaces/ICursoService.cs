using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
   public interface ICursoService
    {
        Task<CursoDTO> Post(CursoDTO cursoDTO);
        Task<CursoDTO> Update(CursoDTO cursoDTO);
        Task Remove(long id);
        Task<CursoDTO> Get(long id);
        Task<List<CursoDTO>> Get();
    }
}
