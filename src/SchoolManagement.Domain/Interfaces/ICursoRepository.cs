using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<List<Curso>> Get();
        Task<Curso> Get(long id);
        Task Remove(long id);
    }
}
