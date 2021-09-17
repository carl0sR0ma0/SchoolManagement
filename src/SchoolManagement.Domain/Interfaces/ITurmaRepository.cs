using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<List<Turma>> Get();
        Task<Turma> Get(long id);
        Task Remove(long id);
    }
}
