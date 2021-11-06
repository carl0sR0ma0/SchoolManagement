using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
   public interface IDisciplinaService
    {
        Task<DisciplinaDTO> Post(DisciplinaDTO disciplinaDTO);
        Task<DisciplinaDTO> Update(DisciplinaDTO disciplinaDTO);
        Task Remove(long id);
        Task<DisciplinaDTO> Get(long id);
        Task<List<DisciplinaDTO>> Get();
    }
}
