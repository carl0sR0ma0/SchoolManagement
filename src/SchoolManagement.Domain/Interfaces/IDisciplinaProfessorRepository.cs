using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IDisciplinaProfessorRepository : IRepository<DisciplinaProfessor>
    {
        Task<List<DisciplinaProfessor>> Get();
        Task<DisciplinaProfessor> Get(long id);
        Task<List<DisciplinaProfessor>> GetDisciplinasByProfessor(long professorId);
        Task<List<DisciplinaProfessor>> GetProfessorByDisciplina(long disciplinaId);
        Task Remove(long id);
    }
}
