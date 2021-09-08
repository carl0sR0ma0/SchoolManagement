using SchoolManagement.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<AlunoDTO> Post(AlunoDTO alunoDTO);
        Task<AlunoDTO> Update(AlunoDTO alunoDTO);
        Task Remove(long id);
        Task<AlunoDTO> Get(long id);
        Task<List<AlunoDTO>> Get();
        Task<AlunoDTO> GetByRA(long ra);
    }
}
