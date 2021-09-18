using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
   public interface ITurmaService
    {
        Task<TurmaDTO> Post(TurmaDTO turmaDTO);
        Task<TurmaDTO> Update(TurmaDTO turmaDTO);
        Task Remove(long id);
        Task<TurmaDTO> Get(long id);
        Task<List<TurmaDTO>> Get();
    }
}
