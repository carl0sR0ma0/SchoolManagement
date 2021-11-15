using SchoolManagement.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Services.Interfaces
{
   public interface IDisciplinaProfessorService
    {
        Task<DisciplinaProfessorDTO> Post(DisciplinaProfessorDTO disciplinaDTO);
        Task<DisciplinaProfessorDTO> Update(DisciplinaProfessorDTO disciplinaDTO);
        Task Remove(long id);
        Task<DisciplinaProfessorDTO> Get(long id);
        Task<List<DisciplinaProfessorDTO>> GetDisciplinasByProfessor(long professorId);
        Task<List<DisciplinaProfessorDTO>> GetProfessorByDisciplina(long disciplinaId);
        Task<List<DisciplinaProfessorDTO>> Get();
    }
}
