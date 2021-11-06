using SchoolManagement.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<List<Disciplina>> Get();
        Task<Disciplina> Get(long id);
        Task Remove(long id);
    }
}
