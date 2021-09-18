using SchoolManagement.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<ProfessorDTO> Post(ProfessorDTO professorDTO);
        Task<ProfessorDTO> Update(ProfessorDTO professorDTO);
        Task Remove(long id);
        Task<ProfessorDTO> Get(long id);
        Task<List<ProfessorDTO>> Get();
    }
}
