using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<List<Professor>> Get();
        Task<Professor> Get(long id);
        Task Remove(long id);
    }
}
