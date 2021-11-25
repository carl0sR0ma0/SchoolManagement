using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IDisciplinaMatriculadaService
    {
        Task<DisciplinaMatriculadaDTO> Post(DisciplinaMatriculadaDTO disciplinaDTO);
        Task<DisciplinaMatriculadaDTO> Update(DisciplinaMatriculadaDTO disciplinaDTO);
        Task Remove(long id);
        Task<DisciplinaMatriculadaDTO> Get(long id);
        Task<List<DisciplinaMatriculadaDTO>> Get();
    }
}
